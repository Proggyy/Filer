namespace Filer.Api.Configurations;

public static class CorsConfiguration{
    public static void ConfigureCors(this IServiceCollection services){
        services.AddCors(options => {
            options.AddPolicy("AllowAll", builder => 
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );
        });
    }

    public static void AddCorsToApplication(this WebApplication app, IConfiguration configuration){
        var policyName = configuration.GetSection("CorsPolicy").Value;
        app.UseCors(policyName!);
    }
}