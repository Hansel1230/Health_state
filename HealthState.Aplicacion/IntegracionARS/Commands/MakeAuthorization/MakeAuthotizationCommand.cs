using AutoMapper;
using HealthState.Aplicacion.Clientes.Constantes;
using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.IntegracionARS.Model;
using HealthState.Aplicacion.Interfaces.Servicios;
using HealthState.Aplicacion.Paciente.Models;
using HealthState.Dominio.Enum;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace HealthState.Aplicacion.IntegracionARS.Commands.MakeAuthorization
{
    public class MakeAuthotizationCommand : IRequest<RespuestaSolicitud>
    {
        public string? TipoDocumento { get; set; }

        [Required(ErrorMessage = "Debe ingresar el número del documento.")]
        public string NumeroDocumento { get; set; }
        public int? NumeroPoliza { get; set; }

        [Required(ErrorMessage = "Debe ingresar el tipo de autorización.")]
        public string TipoSolicitud { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Debe ingresar el monto solicitado.")]
        public decimal MontoSolicitud { get; set; }
    }

    public class MakeAuthorizationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAvalancheService avalancheService) : IRequestHandler<MakeAuthotizationCommand, RespuestaSolicitud>
    {
        public async Task<RespuestaSolicitud> Handle(MakeAuthotizationCommand command, CancellationToken cancellationToken)
        {
            RespuestaSolicitud result = new();
            try
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

                if(command.NumeroPoliza != null && command.NumeroPoliza != 0)
                {
                    poliza = command.NumeroPoliza.ToString();
                }else if(paciente.PolizaId != null && paciente.PolizaId != 0)
                {
                    poliza = paciente.PolizaId.ToString();
                }
                
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

                try
                {
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

                    var avalancheResponse = await avalancheService.MakeAuthorizationAsync(request);

                    if(avalancheResponse.AuthorizationStatus != "Pendiente")
                    {
                        entity.EstadoId = (int?)(avalancheResponse.AuthorizationStatus == "Aprobada" ? EstadoEnum.A : EstadoEnum.R);
                        entity.MontoAprobado = (decimal?)avalancheResponse.ApprovedAmount;

                        solicitudeRepository.UpdateAsync(entity);
                        await unitOfWork.SaveChangesAsync();
                    }

                    result.NumeroSolicitud = entity.SolicitudId;
                    result.Estado = avalancheResponse.AuthorizationStatus;
                    result.Descripcion = command.Descripcion;
                    result.TipoDocumento = avalancheResponse.DocumentType;
                    result.NumeroDocumento = avalancheResponse.DocumentNumber;
                    result.NumeroPoliza = avalancheResponse.PolicyNumber;
                    result.TipoSolicitud = avalancheResponse.AuthorizationType;
                    result.MontoSolicitud = (decimal)avalancheResponse.ApplicationAmount;
                    result.MontoAprobado = (decimal?)avalancheResponse.ApprovedAmount;
                    result.Observaciones = command.Observaciones;
                    result.Hospital = avalancheResponse.Hospital;
                }
                catch(Exception ex)
                {
                    throw new Exception("Hubo un error al enviar autorización");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }
    }
}
