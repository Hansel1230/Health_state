using HealthState.Aplicacion.Auth.Services;
using HealthState.Infraestructura.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthState.Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthHttpService, AuthHttpService>();
            services.AddScoped<IPasswordService, PasswordService>();

            return services;
        }
    }
}
