using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Usuarios.Commands;
using MediatR;

namespace HealthState.Aplicacion.Usuarios.Handlers
{
    public class UsuarioDeleteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UsuarioDeleteCommand>
    {
        public async Task Handle(UsuarioDeleteCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Usuario>();

            var entity = await repository.FirstAsync(x => x.UsuarioId == request.Id);

            if (entity == null)
                throw BusinessException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist, request.Id));

            repository.Delete(entity);

            await unitOfWork.SaveChangesAsync();
        }
    }
}