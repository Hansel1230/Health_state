using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Rol.Commands;
using HealthState.Aplicacion.Rol.Models;
using MediatR;


namespace HealthState.Aplicacion.Rol.Handlers
{
    public class RolCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<RolCreateCommand, RolModel>
    {
        public async Task<RolModel> Handle(RolCreateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Role>();

            if (await repository.ExistAsync(x => x.Nombre == request.Nombre))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Nombre));

            var entity = mapper.Map<HealthState.Dominio.Role>(request);

            await repository.InsertAsync(entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<RolModel>(entity);

        }
    }
}
