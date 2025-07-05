using HealthState.Aplicacion.Aseguradora.Commands;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using MediatR;

namespace HealthState.Aplicacion.Aseguradora.Handlers
{
    public class AseguradoraDeleteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AseguradoraDeleteCommand>
    {
        public async Task Handle(AseguradoraDeleteCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Aseguradora>();

            var entity = await repository.FirstAsync(x => x.AseguradoraId == request.Id);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            repository.Delete(entity);

            await unitOfWork.SaveChangesAsync();
        }
    }
}