using System.Text;
using Filer.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Filer.Api.Configurations;

public static class AuthorizationConfiguration{
    public static void AddJwtAuthorization(this IServiceCollection serviceCollection, IConfiguration configuration){
        var config = configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>()!;

        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
            options.TokenValidationParameters = new TokenValidationParameters{
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey))
            };
            options.Events = new JwtBearerEvents{
                OnMessageReceived = context => {
                    context.Token = context.Request.Cookies["AuthToken"];
                    return Task.CompletedTask;
                }
            };
        });
        serviceCollection.AddAuthorization();
    }
}
