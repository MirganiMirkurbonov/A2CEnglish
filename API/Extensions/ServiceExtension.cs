using Application.Extensions;
using DataAccess.Extensions;
using Database.Extensions;
using Domain.Extensions;
using Infrastructure.Extensions;

namespace API.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddDomain(configuration)
            .AddDatabase(configuration)
            .AddDataAccess(configuration)
            .AddApplication(configuration)
            .AddInfrastructure(configuration);
        
        return services;
    }
}