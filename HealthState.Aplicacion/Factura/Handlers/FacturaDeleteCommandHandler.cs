using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Factura.Commands;
using MediatR;

namespace HealthState.Aplicacion.Factura.Handlers
{
    public class FacturaDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<FacturaDeleteCommand>
    {
        public async Task Handle(FacturaDeleteCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Factura>();

            var entity = await repository.FirstAsync(x => x.FacturaId == request.Id);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist, request.Id));

            repository.Delete(entity);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
