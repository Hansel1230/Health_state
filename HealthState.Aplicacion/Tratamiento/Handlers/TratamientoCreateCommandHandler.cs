using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Tratamiento.Commands;
using HealthState.Aplicacion.Tratamiento.Models;
using MediatR;

namespace HealthState.Aplicacion.Tratamiento.Handlers
{
    public class TratamientoCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<TratamientoCreateCommand, TratamientoModel>
    {
        public async Task<TratamientoModel> Handle(TratamientoCreateCommand request, CancellationToken cancellationToken)
        {
            var repositoryTratamiento = unitOfWork.GetRepository<HealthState.Dominio.Tratamiento>();

            var entityTratamiento = mapper.Map<HealthState.Dominio.Tratamiento>(request);

            await repositoryTratamiento.InsertAsync(entityTratamiento);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<TratamientoModel>(entityTratamiento);

        }
    }
}