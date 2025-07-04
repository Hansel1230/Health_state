using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Factura.Commands;
using HealthState.Aplicacion.Factura.Models;
using MediatR;

namespace HealthState.Aplicacion.Factura.Handlers
{
    public class FacturaCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<FacturaCreateCommand, FacturaModel>
    {
        public async Task<FacturaModel> Handle(FacturaCreateCommand request, CancellationToken cancellationToken)
        {
            var repositoryPaciente = unitOfWork.GetRepository<HealthState.Dominio.Paciente>();

            if (!await repositoryPaciente.ExistAsync(x => x.Cedula == request.Cedula))
                throw NotFoundException.Instance(string.Format(MessageResource.EntityNotExist, request.Cedula));
            
            var entityPaciente = await repositoryPaciente.FirstAsync(x => x.Cedula == request.Cedula);

            var repositoryFactura = unitOfWork.GetRepository<HealthState.Dominio.Factura>();

            var entityFactura = mapper.Map<HealthState.Dominio.Factura>(request);

            entityFactura.PacienteId = entityPaciente.PacienteId;
            await repositoryFactura.InsertAsync(entityFactura);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<FacturaModel>(entityFactura);
        }
    }
}
