using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Rol.Models;
using HealthState.Aplicacion.Solicitud.Commands;
using HealthState.Aplicacion.Solicitud.Models;
using MediatR;

namespace HealthState.Aplicacion.Solicitud.Handlers
{
    public class SolicitudUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<SolicitudUpdateCommand, SolicitudModel>
    {
        public async Task<SolicitudModel> Handle(SolicitudUpdateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Solicitude>();

            var entity = await repository.FirstAsync(x => x.SolicitudId == request.SolicitudId);
            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            var paciente = await ValidateDependenciesAsync(request);


            if (paciente.Aseguradora == null)
                throw NotFoundException.Instance("Este paciente no esta asociado a una aseguradora");

            entity.PolizaId = paciente.PolizaId;
            entity.AseguradoraId = paciente.AseguradoraId;
            entity.PacienteId = paciente.PacienteId;

            mapper.Map(request, entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<SolicitudModel>(entity);
        }

        private async Task<HealthState.Dominio.Paciente> ValidateDependenciesAsync(SolicitudUpdateCommand request)
        {
            var repositoryEstado = unitOfWork.GetRepository<HealthState.Dominio.Estado>();
            var repositoryTipo = unitOfWork.GetRepository<HealthState.Dominio.TipoSolicitude>();
            var repositoryPaciente = unitOfWork.GetRepository<HealthState.Dominio.Paciente>();

            var estadoExists = await repositoryEstado.ExistAsync(x => x.EstadoId == request.EstadoId);
            var tipoExists = await repositoryTipo.ExistAsync(x => x.TipoId == request.TipoId);
            var pacienteExists = await repositoryPaciente.ExistAsync(x => x.Cedula == request.Cedula);

            if (!estadoExists)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "estado", request.EstadoId));

            if (!tipoExists)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "tipo de solicitud", request.TipoId));

            if (!pacienteExists)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "cedula", request.Cedula));

            return await repositoryPaciente.FirstAsync(x => x.Cedula == request.Cedula, includeProperties: new[] { "Aseguradora" });
        }
    }
}