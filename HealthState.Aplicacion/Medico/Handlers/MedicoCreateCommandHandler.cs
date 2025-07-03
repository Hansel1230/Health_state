using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Medico.Commands;
using HealthState.Aplicacion.Medico.Models;
using MediatR;

namespace HealthState.Aplicacion.Medico.Handlers
{
    public class MedicoCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<MedicoCreateCommand, MedicoModel>
    {
        public async Task<MedicoModel> Handle(MedicoCreateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Medico>();

            if (await repository.ExistAsync(x => x.Cedula == request.Cedula))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Cedula));

            var entity = mapper.Map<HealthState.Dominio.Medico>(request);

            await repository.InsertAsync(entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<MedicoModel>(entity);

        }
    }
}
