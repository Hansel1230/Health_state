using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Aplicacion.Rol.Models;
using HealthState.Aplicacion.Rol.Queries;
using MediatR;

namespace HealthState.Aplicacion.Rol.Handlers
{
    public class RolGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<RolGetAllQuery, IEnumerable<RolModel>>
    {
        public async Task<IEnumerable<RolModel>> Handle(RolGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Role>();
            
            var query = PredicateBuilder.Build<HealthState.Dominio.Role>();

            var data = await repository.GetAsync(
                query,
                orderBy: x => x.OrderByDescending(role => role.RolId));

            return mapper.Map<IEnumerable<RolModel>>(data);
        }
    }
}
