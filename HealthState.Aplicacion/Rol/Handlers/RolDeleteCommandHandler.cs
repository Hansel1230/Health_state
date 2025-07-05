using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Rol.Commands;
using MediatR;

namespace HealthState.Aplicacion.Rol.Handlers
{
    public class RolDeleteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RolDeleteCommand>
    {
        public async Task Handle(RolDeleteCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Role>();

            var entity = await repository.FirstAsync(x => x.RolId == request.Id);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            repository.Delete(entity);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
