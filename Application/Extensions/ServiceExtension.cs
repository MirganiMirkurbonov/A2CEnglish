using System.Reflection;
using Application.AdminLogics.Course;
using Application.Logics.Course;
using Application.Logics.User;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        config.Scan(Assembly.GetExecutingAssembly());

        // Disable default mapping for all types (optional, for strict mapping)
        config.Default.IgnoreNonMapped(true);
        
        // for admin
        services
            .AddScoped<ICourseAdminService, CourseAdminService>();
        // for user
        services
            .AddScoped<IUser, UserService>()
            .AddScoped<ICourse, CourseService>();

        return services;
    }
}