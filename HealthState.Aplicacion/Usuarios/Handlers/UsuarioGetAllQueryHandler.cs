using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Aplicacion.Usuarios.Models;
using HealthState.Aplicacion.Usuarios.Queries;
using MediatR;

namespace HealthState.Aplicacion.Usuarios.Handlers
{
    public class UsuarioGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UsuarioGetAllQuery, PaginationResponseModel<UsuarioModel>>
    {
        public async Task<PaginationResponseModel<UsuarioModel>> Handle(UsuarioGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Usuario>();
            var query = PredicateBuilder.Build<HealthState.Dominio.Usuario>();

            if (!string.IsNullOrEmpty(request.Search))
                query = query.And(x => x.Usuario1.Equals(request.Search));

            var totalCount = await repository.CountAsync();

            if (totalCount == 0)
                return new PaginationResponseModel<UsuarioModel>(Enumerable.Empty<UsuarioModel>(), 0);

            var data = await repository.GetAsync(query, orderBy: x => x.OrderByDescending(x => x.UsuarioId),
                skip: request.Skip, take: request.Take, includeProperties: [nameof(HealthState.Dominio.Usuario.Rol)]);
            return new PaginationResponseModel<UsuarioModel>(mapper.Map<IEnumerable<UsuarioModel>>(data),
                totalCount,
                request.Skip,
                request.Take);

        }
    }
}
