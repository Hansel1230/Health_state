using HealthState.Aplicacion.Auth.Services;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Infraestructura.Data;
using HealthState.Infraestructura.Repository;
using HealthState.Infraestructura.Services;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<HealthStateDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HealthState"));
            });
            return services;
        }
    }
}
