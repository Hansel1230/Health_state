using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Usuarios.Commands;
using HealthState.Aplicacion.Usuarios.Models;
using MediatR;
using HealthState.Dominio; // Asegúrate de tener este using

namespace HealthState.Aplicacion.Usuarios.Handlers
{
    public class UsuarioCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UsuarioCreateCommand, UsuarioModel>
    {
        public async Task<UsuarioModel> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Usuario>();

            if (await repository.ExistAsync(x => x.Usuario1 == request.Usuario1))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Usuario1));

            var rolRepository = unitOfWork.GetRepository<HealthState.Dominio.Role>();

            if (!await rolRepository.ExistAsync(x => x.RolId == request.RolId.Value))
                throw BusinessException.Instance(string.Format(MessageResource.EntityReferencedNotExist, request.RolId));

            var rolEntity = await rolRepository.FirstAsync(x => x.RolId == request.RolId.Value);

            var entity = mapper.Map<HealthState.Dominio.Usuario>(request);

            entity.Rol = rolEntity;

            await repository.InsertAsync(entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<UsuarioModel>(entity);
        }
    }
}