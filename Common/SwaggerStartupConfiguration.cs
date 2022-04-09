using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Common
{
    public static class SwaggerStartupConfiguration
    {
        /// <summary>
        /// Define the Swagger Definitions
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void SetupSwaggerDefinition(this IServiceCollection services, SwaggerConfiguration configuration)
        {
            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc($"{configuration.SwaggerVersion}", new OpenApiInfo
                {
                    Title = $"{configuration.SwaggerProjectName} ({configuration.SwaggerVersion})",
                    Version = $"{configuration.SwaggerProjectVersion}",
                    Description = $"{configuration.SwaggerDescription}"
                });

                var xmlCommentsPath = XmlCommentsPath();

                if (File.Exists(xmlCommentsPath))
                    opts.IncludeXmlComments(xmlCommentsPath);

                opts.IgnoreObsoleteActions();
                opts.IgnoreObsoleteProperties();

                opts.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Description = "Input your username and password to access this API",
                    In = ParameterLocation.Header,
                });

                opts.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basicAuth"
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }
        /// <summary>
        /// Sets up the default routing
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        public static void UseSwagger(this IApplicationBuilder app, SwaggerConfiguration configuration)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(opts =>
            {
                opts.SwaggerEndpoint(
                    $"/swagger/{configuration.SwaggerVersion}/swagger.json",
                    $"{configuration.SwaggerProjectName} ({configuration.SwaggerVersion})");
                opts.RoutePrefix = string.Empty;
            });
        }

        /// <summary>
        /// Get the XML Comments for the project
        /// </summary>
        private static string XmlCommentsPath()
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            return Path.Combine(basePath, $"{System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name}.XML");
        }
    }
}
