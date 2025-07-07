using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.DetalleFactura.Commands;
using HealthState.Aplicacion.DetalleFactura.Models;
using MediatR;

namespace HealthState.Aplicacion.DetalleFactura.Handlers
{
    public class DetalleFacturaCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DetalleFacturaCreateCommand, DetalleFacturaModel>
    {
        public async Task<DetalleFacturaModel> Handle(DetalleFacturaCreateCommand request, CancellationToken cancellationToken)
        {
            var repositoryFactura = unitOfWork.GetRepository<HealthState.Dominio.Factura>();

            if(!await repositoryFactura.ExistAsync(x => x.FacturaId == request.FacturaId))
                throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "factura", request.FacturaId));

            var repositoryTratamiento = unitOfWork.GetRepository<HealthState.Dominio.Tratamiento>();

            if (!await repositoryTratamiento.ExistAsync(x => x.TratamientoId == request.TratamientoId))
                throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "tratamiento", request.TratamientoId));

            var repositoryDetalle = unitOfWork.GetRepository<HealthState.Dominio.DetalleFactura>();

            var entityDetalle = mapper.Map<HealthState.Dominio.DetalleFactura>(request);

            await repositoryDetalle.InsertAsync(entityDetalle);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<DetalleFacturaModel>(entityDetalle);
        }
    }
}
