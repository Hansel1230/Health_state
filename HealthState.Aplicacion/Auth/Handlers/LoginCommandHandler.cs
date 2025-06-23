using AutoMapper;
using HealthState.Aplicacion.Auth.Commands;
using HealthState.Aplicacion.Auth.Models;
using HealthState.Aplicacion.Auth.Services;
using HealthState.Aplicacion.Common.Exceptions;
using MediatR;
using HealthState.Aplicacion.Auth;
using HealthState.Aplicacion.Auth.Resources;

namespace HealthState.Aplicacion.Auth.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthApiUserModel>
    {
        private readonly IAuthHttpService authHttpService;
        private readonly IMapper mapper;

        public LoginCommandHandler(IAuthHttpService authHttpService, IMapper mapper)
        {
            this.authHttpService = authHttpService;
            this.mapper = mapper;
        }

        public async Task<AuthApiUserModel> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var model = mapper.Map<AuthApiLoginModel>(command);
            var response = await authHttpService.LoginAsync(model);

            if (response == null) throw new BusinessException(AuthResource.UserNotFound);

            return response;
        }
    }
}
