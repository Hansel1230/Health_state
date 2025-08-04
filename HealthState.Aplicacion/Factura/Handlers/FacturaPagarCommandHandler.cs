using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Factura.Commands;
using HealthState.Aplicacion.Factura.Models;
using MediatR;

namespace HealthState.Aplicacion.Factura.Handlers
{
    public class FacturaPagarCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<FacturaPagarCommand, FacturaModel>
    {
        public async Task<FacturaModel> Handle(FacturaPagarCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Factura>();
            var entity = await repository.FirstAsync(x => x.FacturaId == request.FacturaId);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            entity.Pagado = true;
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<FacturaModel>(entity);
        }
    }
}