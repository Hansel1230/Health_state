using FluentValidation;
using HealthState.Aplicacion.Clientes;
using HealthState.Aplicacion.Common.Behaviors;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Aplicacion.Interfaces.Clientes;
using HealthState.Aplicacion.Interfaces.Servicios;
using HealthState.Aplicacion.Servicios;
using HealthState.Dominio.Settings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HealthState.Aplicacion
{
    public static class ApplicationBuilderExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<IUtilidadesJwt, UtilidadesJwt>();

            #region Configuraciones
            // Access to replace placeholders
            var avalancheApiSection = configuration.GetSection("AvalancheApi");
            var avalancheApiSettings = avalancheApiSection.Get<AvalancheApiSettings>();

            // Replace placeholders in settings
            avalancheApiSettings.UserName = Environment.GetEnvironmentVariable("AVALANCHEAPI_USERNAME");
            avalancheApiSettings.Password = Environment.GetEnvironmentVariable("AVALANCHEAPI_PASSWORD");
            avalancheApiSettings.AuthBaseUrl = Environment.GetEnvironmentVariable("AVALANCHEAPIAUTH_BASEURL");
            avalancheApiSettings.BaseUrl = Environment.GetEnvironmentVariable("AVALANCHEAPI_BASEURL");

            // Configuring RefreshJWT settings
            service.Configure<AvalancheApiSettings>(options =>
            {
                options.UserName = avalancheApiSettings.UserName;
                options.Password = avalancheApiSettings.Password;
                options.AuthBaseUrl = avalancheApiSettings.AuthBaseUrl;
                options.BaseUrl = avalancheApiSettings.BaseUrl;
                options.Authentication = avalancheApiSettings.Authentication;
            });
            #endregion

            #region Servicios
            service.AddHttpClient<IAvalancheAuthApiClient, AvalancheAuthApiClient>(c =>
            {
                c.BaseAddress = new Uri(avalancheApiSettings.AuthBaseUrl);
                c.Timeout = TimeSpan.FromSeconds(30);
            });

            service.AddHttpClient<IAvalancheApiClient, AvalancheApiClient>(c =>
            {
                c.BaseAddress = new Uri(avalancheApiSettings.BaseUrl);
                c.Timeout = TimeSpan.FromSeconds(30);
            });
            service.AddSingleton<ITokenService, TokenService>();
            service.AddScoped<IAvalancheService, AvalancheService>();
            #endregion

            //LIBRERIAS
            service.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            //VALIDADORES
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            return service;
        }
    }
}
