using AutoMapper;
using HealthState.Aplicacion.Aseguradora.Models;
using HealthState.Aplicacion.Aseguradora.Queries;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Dominio;
using MediatR;

namespace HealthState.Aplicacion.Aseguradora.Handlers
{
    public class AseguradoraGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AseguradoraGetAllQuery, PaginationResponseModel<AseguradoraModel>>
    {
        public async Task<PaginationResponseModel<AseguradoraModel>> Handle(AseguradoraGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Aseguradora>();
            var query = PredicateBuilder.Build<HealthState.Dominio.Aseguradora>();

            if(!string.IsNullOrEmpty(request.Search))
                query = query.And(x => x.Nombre.ToLower().Contains(request.Search));

            var totalCount = await repository.CountAsync();

            if(totalCount == 0)
                return new PaginationResponseModel<AseguradoraModel>(Enumerable.Empty<AseguradoraModel>(),0);

            var data = await repository.GetAsync(query, orderBy: x => x.OrderByDescending(x => x.AseguradoraId),
                skip: request.Skip, take: request.Take);
            return new PaginationResponseModel<AseguradoraModel>(mapper.Map<IEnumerable<AseguradoraModel>>(data),
                totalCount,
                request.Skip,
                request.Take);

        }
    }
}
