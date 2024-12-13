using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}