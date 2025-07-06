using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Tratamiento.Commands;
using MediatR;

namespace HealthState.Aplicacion.Tratamiento.Handlers
{
    public class TratamientoDeleteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<TratamientoDeleteCommand>
    {
        public async Task Handle(TratamientoDeleteCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Tratamiento>();

            var entity = await repository.FirstAsync(x => x.TratamientoId == request.Id);

            if (entity == null)
                throw BusinessException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            repository.Delete(entity);

            await unitOfWork.SaveChangesAsync();
        }
    }
}