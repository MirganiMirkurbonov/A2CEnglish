using System.Reflection;
using Application.Extensions;
using DataAccess.Extensions;
using Database.Extensions;
using Domain.Extensions;
using Domain.Models.Response;
using Infrastructure.Extensions;
using Mapster;
using Microsoft.AspNetCore.Mvc;

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
        
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        return services;
    }

    public static IServiceCollection AddHandlerForBadRequest(this IServiceCollection services)
    {
        return services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var error = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new
                    {
                        Field = x.Key,
                        Message = x.Value.Errors.First().ErrorMessage // Get the first error message
                    })
                    .FirstOrDefault(); // Get the first error object

                if (error != null)
                {
                    return new BadRequestObjectResult(new DefaultResponse<string>(new ErrorModel
                    {
                        Code = "400",
                        Message = error.Message
                    }));
                }

                return new BadRequestObjectResult(new DefaultResponse<string>(new ErrorModel
                {
                    Code = "400",
                    Message = "An unknown error occurred."
                }));
            };
        });
    }
}