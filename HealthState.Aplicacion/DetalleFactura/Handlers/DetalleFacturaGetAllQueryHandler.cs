using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.DetalleFactura.Models;
using HealthState.Aplicacion.DetalleFactura.Queries;
using MediatR;

namespace HealthState.Aplicacion.DetalleFactura.Handlers
{
    public class DetalleFacturaGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DetalleFacturaGetAllQuery, PaginationResponseModel<DetalleFacturaModel>>
    {
        public async Task<PaginationResponseModel<DetalleFacturaModel>> Handle(DetalleFacturaGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.DetalleFactura>();
            //var query = PredicateBuilder.Build<HealthState.Dominio.DetalleFactura>();

            //if (!string.IsNullOrEmpty(request.Search))
            //    query = query.And(x => x.Nombre.ToLower().Contains(request.Search));

            var totalCount = await repository.CountAsync();

            if (totalCount == 0)
                return new PaginationResponseModel<DetalleFacturaModel>(Enumerable.Empty<DetalleFacturaModel>(), 0);

            var data = await repository.GetAsync(orderBy: x => x.OrderByDescending(x => x.DetalleId),
                skip: request.Skip, take: request.Take);
            return new PaginationResponseModel<DetalleFacturaModel>(mapper.Map<IEnumerable<DetalleFacturaModel>>(data),
                totalCount,
                request.Skip,
                request.Take);

        }
    }
}
