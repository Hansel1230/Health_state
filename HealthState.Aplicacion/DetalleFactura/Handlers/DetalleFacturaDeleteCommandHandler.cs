using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.DetalleFactura.Commands;
using MediatR;

namespace HealthState.Aplicacion.DetalleFactura.Handlers
{
    public class DetalleFacturaDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DetalleFacturaDeleteCommand>
    {
        public async Task Handle(DetalleFacturaDeleteCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.DetalleFactura>();

            var entity = await repository.FirstAsync(x => x.DetalleId == request.Id);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            repository.Delete(entity);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
