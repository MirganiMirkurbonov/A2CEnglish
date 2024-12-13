using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}