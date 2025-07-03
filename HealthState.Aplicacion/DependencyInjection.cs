using FluentValidation;
using HealthState.Aplicacion.Common.Behaviors;
using HealthState.Aplicacion.Common.Configurations;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Utils;
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
