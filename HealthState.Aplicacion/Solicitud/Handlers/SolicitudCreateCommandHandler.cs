using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Solicitud.Commands;
using HealthState.Aplicacion.Solicitud.Models;
using HealthState.Dominio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HealthState.Aplicacion.Solicitud.Handlers
{
    public class SolicitudCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<SolicitudCreateCommand, SolicitudModel>
    {
        public async Task<SolicitudModel> Handle(SolicitudCreateCommand request, CancellationToken cancellationToken)
        {
            var paciente = await ValidateDependenciesAsync(request);

            var repository = unitOfWork.GetRepository<HealthState.Dominio.Solicitude>();

            var entity = mapper.Map<HealthState.Dominio.Solicitude>(request);

            if(paciente.Aseguradora == null)
                throw NotFoundException.Instance("Este paciente no esta asociado a una aseguradora");

            entity.PolizaId = paciente.PolizaId;
            entity.AseguradoraId = paciente.AseguradoraId;
            entity.PacienteId = paciente.PacienteId;

            await repository.InsertAsync(entity);

            await unitOfWork.SaveChangesAsync();

            var solicitudModel = mapper.Map<SolicitudModel>(entity);
            solicitudModel.Cedula = paciente.Cedula; 

            return solicitudModel;
        }

        private async Task<HealthState.Dominio.Paciente> ValidateDependenciesAsync(SolicitudCreateCommand request)
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