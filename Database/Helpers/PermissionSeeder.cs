using System.Reflection;
using Database.Tables;
using Domain.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;

namespace Database.Helpers;

public class PermissionSeeder(EntityContext dbContext, ILogger<PermissionSeeder> logger)
{
    public void SeedPermissions()
    {
        var controllers = Assembly.GetEntryAssembly()!
            .GetTypes()
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type) &&
                           type.GetCustomAttributes(typeof(AutoPermissionAttribute), false).Any());

        foreach (var controller in controllers)
        {
            var controllerName = controller.Name.Replace("Controller", "");

            var methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(method => method.IsDefined(typeof(HttpMethodAttribute), false));

            foreach (var method in methods)
            {
                var httpAttribute = method.GetCustomAttribute<HttpMethodAttribute>();
                var httpVerb = httpAttribute?.HttpMethods.FirstOrDefault() ?? "UNKNOWN";

                var permissionKeyword = $"{controllerName}.{method.Name}".ToLower();

                // Check if permission already exists
                if (!dbContext.Permissions.Any(p => p.Keyword == permissionKeyword))
                {
                    dbContext.Permissions.Add(new Permission
                    {
                        Keyword = permissionKeyword,
                        Name = $"{httpVerb} {controllerName}/{method.Name}"
                    });
                    logger.LogInformation($"Permission added: {permissionKeyword}");
                }
            }
        }

        dbContext.SaveChanges();
    }
}
