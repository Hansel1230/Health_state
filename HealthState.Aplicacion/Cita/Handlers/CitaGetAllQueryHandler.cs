using AutoMapper;
using HealthState.Aplicacion.Cita.Models;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Common.Utils;
using MediatR;
using HealthState.Aplicacion.Cita.Queries;

namespace HealthState.Aplicacion.Cita.Handlers
{
    public record CitaGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CitaGetAllQuery, PaginationResponseModel<CitaModel>>
    {
        public async Task<PaginationResponseModel<CitaModel>> Handle(CitaGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Cita>();
            var query = PredicateBuilder.Build<HealthState.Dominio.Cita>();

            if (!string.IsNullOrEmpty(request.Search))
                query = query.And(x => x.MotivoConsulta.Contains(request.Search));

            var totalCount = await repository.CountAsync();

            if (totalCount == 0)
                return new PaginationResponseModel<CitaModel>(Enumerable.Empty<CitaModel>(), 0);

            var data = await repository.GetAsync(query, orderBy: x => x.OrderByDescending(x => x.CitaId),
                skip: request.Skip, take: request.Take);
            return new PaginationResponseModel<CitaModel>(mapper.Map<IEnumerable<CitaModel>>(data),
                totalCount,
                request.Skip,
                request.Take);

        }
    }
}
