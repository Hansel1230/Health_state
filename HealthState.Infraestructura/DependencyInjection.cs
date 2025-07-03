using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Infraestructura.Data;
using HealthState.Infraestructura.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthState.Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<HealthStateContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HealthState"));
            });
            return services;
        }
    }
}
