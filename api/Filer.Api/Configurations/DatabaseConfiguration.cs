using Filer.DataAccess;

namespace Filer.Api.Configurations;

public static class DatabaseConfiguration{
    public static void ConfigurePostgresqlDatabase(this IServiceCollection services, IConfiguration configuration){
        var connectionString = configuration.GetSection("ConnectionString").Value;
        services.AddNpgsql<PostContext>(connectionString);
    }
}