using AutoMapper;
using HealthState.Aplicacion.Clientes.Constantes;
using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.IntegracionARS.Model;
using HealthState.Aplicacion.Interfaces.Servicios;
using HealthState.Dominio.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthState.Aplicacion.IntegracionARS.Commands.MakeAuthorization
{
    public class MakeAuthorizationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAvalancheService avalancheService) : IRequestHandler<MakeAuthotizationCommand, RespuestaSolicitud>
    {
        public async Task<RespuestaSolicitud> Handle(MakeAuthotizationCommand command, CancellationToken cancellationToken)
        {
            var pacienteRepository = unitOfWork.GetRepository<HealthState.Dominio.Paciente>();
            var solicitudeRepository = unitOfWork.GetRepository<HealthState.Dominio.Solicitude>();
            var tipoSolicitudeRepository = unitOfWork.GetRepository<HealthState.Dominio.TipoSolicitude>();

            var paciente = await pacienteRepository.FirstAsync(x => x.Cedula == command.NumeroDocumento.ToUpper());
            if (paciente == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            var tipo = await tipoSolicitudeRepository.FirstAsync(x => x.Descripcion == command.TipoSolicitud.ToUpper());
            if (tipo == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            string poliza = "";
            if (command.NumeroPoliza != null && command.NumeroPoliza != 0)
                poliza = command.NumeroPoliza.ToString();
            else if (paciente.PolizaId != null && paciente.PolizaId != 0)
                poliza = paciente.PolizaId.ToString();

            HealthState.Dominio.Solicitude solicitud = new()
            {
                Descripcion = command.Descripcion,
                PacienteId = paciente.PacienteId,
                MontoTotal = command.MontoSolicitud,
                AseguradoraId = paciente.AseguradoraId,
                PolizaId = poliza != "" ? int.Parse(poliza) : null,
                TipoId = tipo.TipoId,
                EstadoId = (int?)EstadoEnum.P,
                Observaciones = command.Observaciones
            };

            var entity = await solicitudeRepository.InsertAsync(solicitud);
            await unitOfWork.SaveChangesAsync();

            var request = new AuthorizationRequestModel()
            {
                ApplicationAmount = (double)command.MontoSolicitud,
                AuthorizationType = command.TipoSolicitud.ToUpper(),
                DocumentNumber = command.NumeroDocumento,
                DocumentType = command.TipoDocumento,
                Hospital = ApiParameters.HospitalName,
                HospitalApplicationId = entity.SolicitudId,
                PolicyNumber = poliza
            };

            AuthorizationResponseModel avalancheResponse;
            try
            {
                avalancheResponse = await avalancheService.MakeAuthorizationAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                throw BusinessException.Instance(ex.Message);
            }

            if (avalancheResponse.Details != null && avalancheResponse.Details.Any())
            {
                var errorMsg = string.Join(" | ", avalancheResponse.Details.Select(d => $"{d.Code}: {d.Message}"));
                throw BusinessException.Instance(errorMsg);
            }

            if (avalancheResponse.AuthorizationStatus != "Pendiente")
            {
                entity.EstadoId = (int?)(avalancheResponse.AuthorizationStatus == "Aprobada" ? EstadoEnum.A : EstadoEnum.R);
                entity.MontoAprobado = (decimal?)avalancheResponse.ApprovedAmount;
                solicitudeRepository.UpdateAsync(entity);
                await unitOfWork.SaveChangesAsync();
            }

            return new RespuestaSolicitud
            {
                NumeroSolicitud = entity.SolicitudId,
                Estado = avalancheResponse.AuthorizationStatus,
                Descripcion = command.Descripcion,
                TipoDocumento = avalancheResponse.DocumentType,
                NumeroDocumento = avalancheResponse.DocumentNumber,
                NumeroPoliza = avalancheResponse.PolicyNumber,
                TipoSolicitud = avalancheResponse.AuthorizationType,
                MontoSolicitud = (decimal)avalancheResponse.ApplicationAmount,
                MontoAprobado = (decimal?)avalancheResponse.ApprovedAmount,
                Observaciones = command.Observaciones,
                Hospital = avalancheResponse.Hospital
            };
        }
    }
}
