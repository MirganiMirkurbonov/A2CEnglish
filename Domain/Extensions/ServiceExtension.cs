using System.Reflection;
using Domain.Models.Options;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddFluentValidationAutoValidation(src=>src.DisableDataAnnotationsValidation = true)
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services
            .Configure<BotOptions>(configuration.GetSection("BotOptions"))
            .Configure<DatabaseOptions>(configuration.GetSection("DatabaseOptions"))
            .Configure<JwtTokenOptions>(configuration.GetSection("JwtTokenOptions"));
    }
}