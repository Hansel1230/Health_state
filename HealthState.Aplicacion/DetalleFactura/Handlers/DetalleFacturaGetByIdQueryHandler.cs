using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.DetalleFactura.Models;
using HealthState.Aplicacion.DetalleFactura.Queries;
using MediatR;

namespace HealthState.Aplicacion.DetalleFactura.Handlers
{
    public class DetalleFacturaGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DetalleFacturaGetByIdQuery, DetalleFacturaModel>
    {
        public async Task<DetalleFacturaModel> Handle(DetalleFacturaGetByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.DetalleFactura>();
            var entity = await repository.FirstAsync(x => x.DetalleId == request.Id);

            return mapper.Map<DetalleFacturaModel>(entity);
        }
    }
}
