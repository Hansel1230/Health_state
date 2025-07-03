using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Rol.Models;
using HealthState.Aplicacion.Rol.Queries;
using MediatR;

namespace HealthState.Aplicacion.Rol.Handlers
{
    public class RolGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<RolGetByIdQuery, RolModel>
    {
        public async Task<RolModel> Handle(RolGetByIdQuery request, CancellationToken cancellationToken)
        {
            var respository = unitOfWork.GetRepository<HealthState.Dominio.Role>();
            var entity = await respository.FirstAsync(x => x.RolId == request.Id);

            return entity == null
                ? throw BusinessException.Instance(string.Format(MessageResource.EntityNotExist, request.Id))
                : mapper.Map<RolModel>(entity);
        }
    }
}
