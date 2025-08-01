using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Solicitud.Models;
using HealthState.Aplicacion.Solicitud.Queries;
using MediatR;

namespace HealthState.Aplicacion.Solicitud.Handlers
{
    public class SolicitudGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<SolicitudGetByIdQuery, SolicitudModel>
    {
        public async Task<SolicitudModel> Handle(SolicitudGetByIdQuery request, CancellationToken cancellationToken)
        {
            var respository = unitOfWork.GetRepository<HealthState.Dominio.Solicitude>();

            var entity = await respository.FirstAsync(x => x.SolicitudId == request.Id, includeProperties:
                 [nameof(HealthState.Dominio.Solicitude.Paciente),
                 nameof(HealthState.Dominio.Solicitude.Estado),
                 nameof(HealthState.Dominio.Solicitude.Aseguradora),
                 nameof(HealthState.Dominio.Solicitude.Tipo)]);

            return mapper.Map<SolicitudModel>(entity);
        }
    }
}
