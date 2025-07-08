using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Aplicacion.Solicitud.Models;
using HealthState.Aplicacion.Solicitud.Queries;
using MediatR;

namespace HealthState.Aplicacion.Solicitud.Handlers
{
    public class SolicitudGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<SolicitudGetAllQuery, PaginationResponseModel<SolicitudModel>>
    {
        public async Task<PaginationResponseModel<SolicitudModel>> Handle(SolicitudGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Solicitude>();
            var query = PredicateBuilder.Build<HealthState.Dominio.Solicitude>();

            if (!string.IsNullOrEmpty(request.Search))
                query = query.And(x => x.Descripcion.Contains(request.Search));

            var totalCount = await repository.CountAsync();

            if (totalCount == 0)
                return new PaginationResponseModel<SolicitudModel>(Enumerable.Empty<SolicitudModel>(), 0);

            var data = await repository.GetAsync(query, orderBy: x => x.OrderByDescending(x => x.SolicitudId),
                skip: request.Skip, take: request.Take, includeProperties: new[] { "Paciente" });
            return new PaginationResponseModel<SolicitudModel>(mapper.Map<IEnumerable<SolicitudModel>>(data),
                totalCount,
                request.Skip,
                request.Take);
        }
    }
}
