using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Usuarios.Commands;
using HealthState.Aplicacion.Usuarios.Models;
using MediatR;

namespace HealthState.Aplicacion.Usuarios.Handlers
{
    public class UsuarioUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUtilidadesJwt utilidades) : IRequestHandler<UsuarioUpdateCommand, UsuarioModel>
    {
        public async Task<UsuarioModel> Handle(UsuarioUpdateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Usuario>();

            var entity = await repository.FirstAsync(x => x.UsuarioId == request.UsuarioId);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            if (await repository.ExistAsync(x => x.Usuario1 == request.Usuario1 && x.UsuarioId != request.UsuarioId))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Usuario1));

            var rolRepository = unitOfWork.GetRepository<HealthState.Dominio.Role>();

            if (!await rolRepository.ExistAsync(x => x.RolId == request.RolId))
                throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "Rol", request.RolId));

            var rolEntity = await rolRepository.FirstAsync(x => x.RolId == request.RolId);

            entity.Rol = rolEntity;
            entity.Contrasena = utilidades.encriptarSha256(request.Contrasena);

            mapper.Map(request, entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<UsuarioModel>(entity);
        }
    }
}
