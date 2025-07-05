using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Factura.Commands;
using HealthState.Aplicacion.Factura.Models;
using MediatR;

namespace HealthState.Aplicacion.Factura.Handlers
{
    public class FacturaUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<FacturaUpdateCommand, FacturaModel>
    {
        public async Task<FacturaModel> Handle(FacturaUpdateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Factura>();

            var entity = await repository.FirstAsync(x => x.FacturaId == request.FacturaId,
                includeProperties: [nameof(HealthState.Dominio.Paciente)]);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            mapper.Map(request, entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<FacturaModel>(entity);
        }
    }
}
