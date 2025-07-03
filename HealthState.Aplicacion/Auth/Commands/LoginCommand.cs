using MediatR;

namespace HealthState.Aplicacion.Auth.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}
