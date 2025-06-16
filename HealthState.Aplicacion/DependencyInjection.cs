using FluentValidation;
using HealthState.Application.Auth.Configurations;
using HealthState.Application.Auth.Services;
using HealthState.Application.Common.Behaviors;
using HealthState.Application.Common.Configurations;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HealthState.Application
{
    public static class ApplicationBuilderExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<AuthConfiguration>(opt =>
            {
                opt.Url = configuration["Auth:Url"];
                opt.AppCode = configuration["Auth:AppCode"];
            });
            service.Configure<JwtConfiguration>(opt =>
            {
                opt.Key = configuration["JWT:Key"];
                opt.Expire = bool.Parse(configuration["JWT:Expire"]);
                opt.ExpireTime = int.Parse(configuration["JWT:ExpireTime"]);
            });

            //LIBRERIAS
            service.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            //VALIDADORES
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            //SERVICIOS 

            return service;
        }
    }
}
