using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Filer.Api.Configurations;

public static class SwaggerConfiguration{
    public static void ConfigureSwagger(this IServiceCollection services){
        services.AddSwaggerGen(opts => {
            opts.AddSecurityDefinition("BearerToken", new OpenApiSecurityScheme{
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                Description = "Enter Bearer with token."
            });

            opts.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme(){
                        Name = "Bearer",
                        Reference = new OpenApiReference(){
                            Id = "BearerToken",
                            Type = ReferenceType.SecurityScheme
                        }
                    }
                    ,new List<string>()
                }
            });
        });
    }
}