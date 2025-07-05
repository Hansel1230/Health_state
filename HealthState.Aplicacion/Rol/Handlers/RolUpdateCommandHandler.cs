using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Rol.Commands;
using HealthState.Aplicacion.Rol.Models;
using MediatR;

namespace HealthState.Aplicacion.Rol.Handlers
{
    public class RolUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<RolUpdateCommand, RolModel>
    {
        public async Task<RolModel> Handle(RolUpdateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Role>();

            var entity = await repository.FirstAsync(x => x.RolId == request.RolId);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            if (await repository.ExistAsync(x => x.Nombre == request.Nombre))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Nombre));

            mapper.Map(request, entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<RolModel>(entity);
        }
    }
}
