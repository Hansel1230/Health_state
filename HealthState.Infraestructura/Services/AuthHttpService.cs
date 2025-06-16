using HealthState.Application.Auth.Configurations;
using HealthState.Application.Auth.Models;
using HealthState.Application.Auth.Services;
using HealthState.Application.Common.Exceptions;
using Microsoft.Extensions.Options;
using Service.Application.Auth.Resources;
using HealthState.Application.Common.Helpers;

namespace HealthState.Infraestructura.Services
{
    public class AuthHttpService : IAuthHttpService
    {
        private readonly HttpClient httpClient;
        private readonly AuthConfiguration authConfiguration;
        public AuthHttpService(IOptions<AuthConfiguration> options)
        {
            authConfiguration = options.Value;
            httpClient = new HttpClient { BaseAddress = new Uri(options.Value.Url) };
        }

        public async Task<AuthApiUserModel> LoginAsync(AuthApiLoginModel model)
        {
            model.AppCode = authConfiguration.AppCode;
            var response = await httpClient.PostJsonAsync<AuthApiLoginModel, AuthApiResponse<AuthApiUserModel>>("api/login/authenticate", model);
            if (!response.Completed && string.IsNullOrWhiteSpace(response.Message)) throw new InvalidOperationException(AuthResource.GeneralErrorAPI);
            if (!response.Completed) throw new BusinessException(response.Message);
            return response.Result;
        }
    }
}
