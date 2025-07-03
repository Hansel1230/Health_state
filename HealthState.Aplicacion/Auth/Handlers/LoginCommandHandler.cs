using HealthState.Aplicacion.Auth.Commands;
using HealthState.Aplicacion.Auth.Resources;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Usuarios.Models;
using MediatR;

namespace HealthState.Aplicacion.Auth.Handlers
{
    public class LoginCommandHandler(IUnitOfWork unitOfWork, IUtilidadesJwt utilidades) : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Usuario>();

            var entity = await repository.FirstAsync(u => u.Usuario1 == request.Usuario
                && u.Contrasena == utilidades.encriptarSha256(request.Clave));

            if (entity == null)
                throw BusinessException.Instance(string.Format(AuthResource.UserNotFound));
            else
            {
                UsuarioModel usuarioModel = new UsuarioModel { Usuario1 = request.Usuario, Contrasena = request.Clave };
                return utilidades.GenerarJwt(usuarioModel);
            }
        }
    }
}
