using HealthState.Aplicacion;
using HealthState.Infraestructura;
using HealthState.Aplicacion.Auth.Services;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace HealthState
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //Add services to container 
            services.AddHttpClient();

            services.AddApplication(Configuration);
            services.AddInfrastructure(Configuration);
            services.AddServer(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthState", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Este API utiliza Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                        },
                        Scheme = "Bearer",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                        } ,
                        new List<string>()
                    }
                });
            });

            services.AddCors(opt => opt.AddPolicy("all", x => x.AllowAnyOrigin()
                                                                .AllowAnyHeader()
                                                                .AllowAnyMethod()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Serilog.ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Service.API v1"));
            }

            app.UseExceptionHandler(x => x.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                if (exception is ValidationException || exception is BusinessException)
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                else
                    logger.Error(exception, exception.Message);

                var result = JsonSerializer.Serialize(new ResponseMessageModel<string>(context.Response.StatusCode, ((HttpStatusCode)context.Response.StatusCode).ToString(), exception.Message));
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("all");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}




