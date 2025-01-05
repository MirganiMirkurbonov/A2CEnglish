using Microsoft.AspNetCore.Http;

namespace Domain.Extensions;

public static class FileExtension
{
    public static IHttpContextAccessor? HttpContextAccessor;

    public static string GetServerPath(this string? path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return string.Empty; // Return an empty string if the path is null or empty
        }

        if (HttpContextAccessor == null)
        {
            throw new InvalidOperationException("IHttpContextAccessor is not configured. Please call FileExtension.Configure() during app startup.");
        }

        var httpContext = HttpContextAccessor.HttpContext;

        if (httpContext == null)
        {
            throw new InvalidOperationException("HttpContext is not available.");
        }

        // Build the base URL
        var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/";

        // Normalize the path to use forward slashes and remove any leading slashes
        var normalizedPath = path.Replace("\\", "/").TrimStart('/');

        // Combine the base URL and the normalized path
        return $"{baseUrl}files/{normalizedPath}";
    }


}