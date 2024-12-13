using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}