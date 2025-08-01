using HealthState.Aplicacion.Auth.Commands;
using HealthState.Aplicacion.Auth.Models;
using HealthState.Aplicacion.Auth.Resources;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Usuarios.Models;
using MediatR;

namespace HealthState.Aplicacion.Auth.Handlers
{
    public class LoginCommandHandler(IUnitOfWork unitOfWork, IUtilidadesJwt utilidades) : IRequestHandler<LoginCommand, AuthModel>
    {
        public async Task<AuthModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Usuario>();

            var entity = await repository.FirstAsync(u => u.Usuario1 == request.Usuario
                && u.Contrasena == utilidades.encriptarSha256(request.Clave));

            if (entity == null)
                throw NotFoundException.Instance(string.Format(AuthResource.UserNotFound));
            else
            {
                UsuarioModel usuarioModel = new UsuarioModel { Usuario1 = request.Usuario, Contrasena = request.Clave };
                var jwt = utilidades.GenerarJwt(usuarioModel);

                return new AuthModel { RolId = entity.RolId, Token = jwt };
            }
        }
    }
}
