using Microsoft.AspNetCore.Mvc;

namespace Filer.Api.Configurations;

public static class ApiConfiguration{
    public static void ConfigureApiOptions(this IServiceCollection services){
        services.Configure<ApiBehaviorOptions>(opt => {
            opt.SuppressModelStateInvalidFilter = true;
        });
    }
}