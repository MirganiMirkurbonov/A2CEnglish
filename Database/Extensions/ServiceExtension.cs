using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<EntityContext>(
            options => options.UseNpgsql(configuration["DatabaseOptions:ConnectionString"]));
        return services;
    }
}