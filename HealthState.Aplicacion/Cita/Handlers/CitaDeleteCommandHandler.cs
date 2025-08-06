using HealthState.Aplicacion.Cita.Commands;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using MediatR;

namespace HealthState.Aplicacion.Cita.Handlers
{
    public class CitaDeleteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CitaDeleteCommand>
    {
        public async Task Handle(CitaDeleteCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Cita>();

            var entity = await repository.FirstAsync(x => x.CitaId == request.Id);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            repository.Delete(entity);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
