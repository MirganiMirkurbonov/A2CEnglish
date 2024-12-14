using BotService.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BotService.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<BotOptions>(configuration.GetSection("BotOptions"));
        return services;
    }
}