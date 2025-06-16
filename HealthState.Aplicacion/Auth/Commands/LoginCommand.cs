using HealthState.Aplicacion.Auth.Models;
using MediatR;

namespace HealthState.Aplicacion.Auth.Commands
{
    public class LoginCommand : IRequest<AuthApiUserModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
