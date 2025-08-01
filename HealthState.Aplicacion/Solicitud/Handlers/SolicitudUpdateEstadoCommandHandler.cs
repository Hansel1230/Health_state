using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Solicitud.Commands;
using HealthState.Aplicacion.Solicitud.Models;
using HealthState.Dominio;
using HealthState.Dominio.Enum;
using MediatR;

namespace HealthState.Aplicacion.Solicitud.Handlers
{
    public class SolicitudUpdateEstadoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<SolicitudUpdateEstadoCommand, SolicitudModel>
    {
        public async Task<SolicitudModel> Handle(SolicitudUpdateEstadoCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Solicitude>();

            var entity = await repository.FirstAsync(x => x.SolicitudId == request.SolicitudId, includeProperties:
                [nameof(HealthState.Dominio.Solicitude.Paciente),
                 nameof(HealthState.Dominio.Solicitude.Estado),
                 nameof(HealthState.Dominio.Solicitude.Aseguradora),
                 nameof(HealthState.Dominio.Solicitude.Tipo)]);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            var estadoRepository = unitOfWork.GetRepository<HealthState.Dominio.Estado>();
            var nuevoEstado = await estadoRepository.FirstAsync(e => e.EstadoId == (int)request.NuevoEstado);

            if (nuevoEstado == null)
                throw BusinessException.Instance(string.Format(MessageResource.InvalidInput));

            if (request.MontoAprobado > entity.MontoTotal)
                throw BusinessException.Instance(string.Format(MessageResource.InvalidAmount));

            entity.EstadoId = (int)request.NuevoEstado;
            entity.MontoAprobado = request.NuevoEstado == EstadoEnum.A ? request.MontoAprobado : 0;

            await unitOfWork.SaveChangesAsync();

            entity.Estado = nuevoEstado;

            return mapper.Map<SolicitudModel>(entity);
        }
    }
}