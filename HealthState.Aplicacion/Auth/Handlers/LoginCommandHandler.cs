using AutoMapper;
using HealthState.Application.Auth.Commands;
using HealthState.Application.Auth.Models;
using HealthState.Application.Auth.Services;
using HealthState.Application.Common.Exceptions;
using MediatR;
using Service.Application.Auth.Resources;

namespace HealthState.Application.Auth.Handlers
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
