using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Medico.Commands;
using MediatR;

namespace HealthState.Aplicacion.Medico.Handlers
{
    public class MedicoDeleteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<MedicoDeleteCommand>
    {
        public async Task Handle(MedicoDeleteCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Medico>();

            var entity = await repository.FirstAsync(x => x.MedicoId == request.Id);

            if (entity == null)
                throw BusinessException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist, request.Id));

            repository.Delete(entity);

            await unitOfWork.SaveChangesAsync();
        }
    }
}