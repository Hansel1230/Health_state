using AutoMapper;
using HealthState.Aplicacion.Aseguradora.Commands;
using HealthState.Aplicacion.Aseguradora.Models;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using MediatR;

namespace HealthState.Aplicacion.Aseguradora.Handlers
{
    public class AseguradoraUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AseguradoraUpdateCommand, AseguradoraModel>
    {
        public async Task<AseguradoraModel> Handle(AseguradoraUpdateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Aseguradora>();

            var entity = await repository.FirstAsync(x => x.AseguradoraId == request.AseguradoraId);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            if (await repository.ExistAsync(x => x.Nombre == request.Nombre && x.AseguradoraId != request.AseguradoraId))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Nombre));

            mapper.Map(request, entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<AseguradoraModel>(entity);
        }
    }
}
