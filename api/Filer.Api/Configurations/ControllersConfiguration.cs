using Filer.Domain.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Filer.Api.Configurations;

public static class ControllersConfiguration{
    public static void ConfigureControllersOptions(this IServiceCollection services){
        services.AddControllers(opt => {
            opt.CacheProfiles.Add("MinuteDuration", new CacheProfile{ 
                Duration = 60, 
                VaryByQueryKeys = typeof(RequestParameters).GetProperties().Select(x => x.Name).ToArray()
                });
            });
    }
}