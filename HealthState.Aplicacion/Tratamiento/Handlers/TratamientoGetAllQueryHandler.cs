using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Aplicacion.Tratamiento.Models;
using HealthState.Aplicacion.Tratamiento.Queries;
using MediatR;

namespace HealthState.Aplicacion.Tratamiento.Handlers
{
    public class TratamientoGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<TratamientoGetAllQuery, PaginationResponseModel<TratamientoModel>>
    {
        public async Task<PaginationResponseModel<TratamientoModel>> Handle(TratamientoGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Tratamiento>();
            var query = PredicateBuilder.Build<HealthState.Dominio.Tratamiento>();

            if (!string.IsNullOrEmpty(request.search))
                query = query.And(x => x.Descripcion.Contains(request.search));

            var totalCount = await repository.CountAsync(query);

            if (totalCount == 0)
                return new PaginationResponseModel<TratamientoModel>(Enumerable.Empty<TratamientoModel>(), 0);

            var data = await repository.GetAsync(query, orderBy: x => x.OrderByDescending(x => x.TratamientoId),
                skip: request.Skip, take: request.Take);

            return new PaginationResponseModel<TratamientoModel>(mapper.Map<IEnumerable<TratamientoModel>>(data),
                totalCount,
                request.Skip,
                request.Take);
        }
    }
}