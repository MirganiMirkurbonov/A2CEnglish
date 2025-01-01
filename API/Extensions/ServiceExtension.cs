using System.Text;
using Application.Extensions;
using Database.Extensions;
using Domain.Extensions;
using Domain.Models.Response;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            .AddApplication(configuration)
            .AddInfrastructure(configuration);
        
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
                        Message = x.Value?.Errors.First().ErrorMessage // Get the first error message
                    })
                    .FirstOrDefault();

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

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "PlumWorkFlow API",
                Description = "PlumWorkFlow API",
                TermsOfService = new Uri("https://example.com/terms")
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = "JWT Bearer token usage. Example: \"Authorization: Bearer { token }\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });



            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }

    public static IServiceCollection AddAuthorizationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtTokenOptions:Issuer"],
                ValidAudience = configuration["JwtTokenOptions:Audience"],
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtTokenOptions:Secret"]!)),
            };

            options.MapInboundClaims = false;
        });
        services.AddAuthorization();
        return services;
    }
}