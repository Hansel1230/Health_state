using HealthState.Application.Auth.Models;
using MediatR;

namespace HealthState.Application.Auth.Commands
{
    public class LoginCommand : IRequest<AuthApiUserModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
