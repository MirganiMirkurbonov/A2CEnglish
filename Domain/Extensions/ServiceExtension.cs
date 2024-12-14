using Domain.Models.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .Configure<BotOptions>(configuration.GetSection("BotOptions"))
            .Configure<DatabaseOptions>(configuration.GetSection("DatabaseOptions"));
    }
}