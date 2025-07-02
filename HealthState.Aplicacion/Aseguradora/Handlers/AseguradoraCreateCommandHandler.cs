using AutoMapper;
using HealthState.Aplicacion.Aseguradora.Commands;
using HealthState.Aplicacion.Aseguradora.Models;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using MediatR;

namespace HealthState.Aplicacion.Aseguradora.Handlers
{
    public class AseguradoraCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AseguradoraCreateCommand, AseguradoraModel>
    {
        public async Task<AseguradoraModel> Handle(AseguradoraCreateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Aseguradora>();

            if(await repository.ExistAsync(x => x.Nombre == request.Nombre))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Nombre));

            var entity = mapper.Map<HealthState.Dominio.Aseguradora>(request);

            await repository.InsertAsync(entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<AseguradoraModel>(entity);

        }
    }
}
