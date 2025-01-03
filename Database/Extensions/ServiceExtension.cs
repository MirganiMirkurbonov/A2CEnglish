﻿using Database.DataAccess;
using Database.Helpers;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<EntityContext>(options =>
        {
            options.UseNpgsql(configuration["DatabaseOptions:ConnectionString"]);
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        });

        services
            .AddScoped<IPermissionDataAccess, PermissionDataAccess>()
            .AddScoped<PermissionSeeder>();

        return services;
    }
}