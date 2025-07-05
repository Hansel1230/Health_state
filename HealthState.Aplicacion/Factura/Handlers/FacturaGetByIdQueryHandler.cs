using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Factura.Models;
using HealthState.Aplicacion.Factura.Queries;
using MediatR;

namespace HealthState.Aplicacion.Factura.Handlers
{
    public class FacturaGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<FacturaGetByIdQuery, FacturaModel>
    {
        public async Task<FacturaModel> Handle(FacturaGetByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Factura>();
            var entity = await repository.FirstAsync(x => x.FacturaId == request.Id);

            return mapper.Map<FacturaModel>(entity);
        }
    }
}
