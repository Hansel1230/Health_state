using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Tratamiento.Models;
using HealthState.Aplicacion.Tratamiento.Queries;
using MediatR;

namespace HealthState.Aplicacion.Tratamiento.Handlers
{
    public class TratamientoGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<TratamientoGetByIdQuery, TratamientoModel>
    {
        public async Task<TratamientoModel> Handle(TratamientoGetByIdQuery request, CancellationToken cancellationToken)
        {
            var respository = unitOfWork.GetRepository<HealthState.Dominio.Tratamiento>();
            var entity = await respository.FirstAsync(x => x.TratamientoId == request.Id);

            return mapper.Map<TratamientoModel>(entity);
        }
    }
}