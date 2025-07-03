using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Medico.Commands;
using HealthState.Aplicacion.Medico.Models;
using MediatR;

namespace HealthState.Aplicacion.Medico.Handlers
{
    public class MedicoUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<MedicoUpdateCommand, MedicoModel>
    {
        public async Task<MedicoModel> Handle(MedicoUpdateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Medico>();

            var entity = await repository.FirstAsync(x => x.MedicoId == request.MedicoId);

            if (entity == null)
                throw BusinessException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist, request.MedicoId));

            if (await repository.ExistAsync(x => x.Cedula == request.Cedula))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Cedula));

            mapper.Map(request, entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<MedicoModel>(entity);
        }
    }
}
