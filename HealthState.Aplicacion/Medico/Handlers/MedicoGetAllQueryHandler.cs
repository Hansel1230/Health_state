using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Aplicacion.Medico.Models;
using HealthState.Aplicacion.Medico.Queries;
using MediatR;

namespace HealthState.Aplicacion.Medico.Handlers
{
    public class AseguradoraGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<MedicoGetAllQuery, PaginationResponseModel<MedicoModel>>
    {
        public async Task<PaginationResponseModel<MedicoModel>> Handle(MedicoGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Medico>();
            var query = PredicateBuilder.Build<HealthState.Dominio.Medico>();

            if (!string.IsNullOrEmpty(request.Search))
                query = query.And(x => x.Nombre.ToLower().Contains(request.Search));

            var totalCount = await repository.CountAsync();

            if (totalCount == 0)
                return new PaginationResponseModel<MedicoModel>(Enumerable.Empty<MedicoModel>(), 0);

            var data = await repository.GetAsync(query, orderBy: x => x.OrderByDescending(x => x.MedicoId),
                skip: request.Skip, take: request.Take);
            return new PaginationResponseModel<MedicoModel>(mapper.Map<IEnumerable<MedicoModel>>(data),
                totalCount,
                request.Skip,
                request.Take);

        }
    }
}
