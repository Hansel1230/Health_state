using HealthState.Aplicacion.Auth.Models;
using MediatR;

namespace HealthState.Aplicacion.Auth.Commands
{
    public class LoginCommand : IRequest<AuthModel>
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}
