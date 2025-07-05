using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Usuarios.Commands;
using HealthState.Aplicacion.Usuarios.Models;
using MediatR;

namespace HealthState.Aplicacion.Usuarios.Handlers
{
    public class UsuarioCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUtilidadesJwt utilidades) : IRequestHandler<UsuarioCreateCommand, UsuarioModel>
    {

        public async Task<UsuarioModel> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Usuario>();

            if (await repository.ExistAsync(x => x.Usuario1 == request.Usuario1))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Usuario1));

            var rolRepository = unitOfWork.GetRepository<HealthState.Dominio.Role>();

            if (!await rolRepository.ExistAsync(x => x.RolId == request.RolId))
                throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "rol", request.RolId));

            var rolEntity = await rolRepository.FirstAsync(x => x.RolId == request.RolId);

            var entity = mapper.Map<HealthState.Dominio.Usuario>(request);

            entity.Rol = rolEntity;
            entity.Contrasena = utilidades.encriptarSha256(request.Contrasena);

            await repository.InsertAsync(entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<UsuarioModel>(entity);
        }
    }
}