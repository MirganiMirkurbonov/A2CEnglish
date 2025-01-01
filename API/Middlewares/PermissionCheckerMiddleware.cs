using Database.Interfaces;
using Domain.Attributes;

namespace API.Middlewares;

internal class PermissionCheckerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var permissionDataAccess = context.RequestServices.GetRequiredService<IPermissionDataAccess>();
        // Get the endpoint metadata
        var endpoint = context.GetEndpoint();
        var controllerDescriptor =
            endpoint?.Metadata.GetMetadata<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>();

        if (controllerDescriptor != null)
        {
            // Get the controller type
            var controllerType = controllerDescriptor.ControllerTypeInfo;

            // Check if the controller has your custom attribute
            var hasAttribute = controllerType.GetCustomAttributes(typeof(AutoPermissionAttribute), false).Any();

            if (hasAttribute)
            {
                // Get the user's role from the JWT token
                var roleClaim = context.User.FindFirst("role"); // Assuming the role is stored in a "role" claim
                if (roleClaim == null)
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Unauthorized: Missing role in JWT.");
                    return;
                }

                var userRole = roleClaim.Value;

                // Get the user's ID from the JWT token
                var userIdClaim = context.User.FindFirst("sub"); // Assuming "sub" is the user's ID
                if (userIdClaim == null)
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Unauthorized: Missing user ID in JWT.");
                    return;
                }

                // Determine the permission name based on the controller and action
                var permissionName = $"{controllerDescriptor.ControllerName}.{controllerDescriptor.ActionName}".ToLower();

                // Retrieve the permissions for the role from the DataAccess layer
                var rolePermissions = await permissionDataAccess.GetRolePermissions(userRole);

                // Check if the required permission is in the role's permission list
                if (rolePermissions.All(x => x.Keyword != permissionName))
                {
                    context.Response.StatusCode = 403; // Forbidden
                    await context.Response.WriteAsync(
                        $"Forbidden: Missing permission '{permissionName}' for role '{userRole}'.");
                    return;
                }
            }
        }

        await next(context);
    }
}
