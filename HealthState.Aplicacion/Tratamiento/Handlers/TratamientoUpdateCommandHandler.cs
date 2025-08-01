using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Tratamiento.Commands;
using HealthState.Aplicacion.Tratamiento.Models;
using MediatR;

namespace HealthState.Aplicacion.Tratamiento.Handlers
{
    public class TratamientoUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<TratamientoUpdateCommand, TratamientoModel>
    {
        public async Task<TratamientoModel> Handle(TratamientoUpdateCommand request, CancellationToken cancellationToken)
        {
            var repositoryCita = unitOfWork.GetRepository<HealthState.Dominio.Cita>();

            var repository = unitOfWork.GetRepository<HealthState.Dominio.Tratamiento>();

            var entity = await repository.FirstAsync(x => x.TratamientoId == request.TratamientoId);

            if (entity == null)
                throw BusinessException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist, request.TratamientoId));

            mapper.Map(request, entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<TratamientoModel>(entity);
        }
    }
}