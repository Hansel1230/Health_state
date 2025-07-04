using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Aplicacion.Factura.Models;
using HealthState.Aplicacion.Factura.Queries;
using MediatR;

namespace HealthState.Aplicacion.Factura.Handlers
{
    public class FacturaGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<FacturaGetAllQuery, PaginationResponseModel<FacturaModel>>
    {
        public async Task<PaginationResponseModel<FacturaModel>> Handle(FacturaGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Factura>();
            var query = PredicateBuilder.Build<HealthState.Dominio.Factura>();

            if (!string.IsNullOrEmpty(request.Search))
                query = query.And(x => x.Paciente.Cedula.Equals(request.Search));

            if (request.FechaInicio.HasValue)
                query = query.And(x => x.FechaEmision >= request.FechaInicio.Value);

            if (request.FechaFin.HasValue)
                query = query.And(x => x.FechaEmision <= request.FechaFin.Value);

            var totalCount = await repository.CountAsync(query); 

            if (totalCount == 0)
                return new PaginationResponseModel<FacturaModel>(Enumerable.Empty<FacturaModel>(), 0);

            var data = await repository.GetAsync(query, orderBy: x => x.OrderByDescending(x => x.FacturaId),
                skip: request.Skip, take: request.Take);

            return new PaginationResponseModel<FacturaModel>(mapper.Map<IEnumerable<FacturaModel>>(data),
                totalCount,
                request.Skip,
                request.Take);
        }
    }
}