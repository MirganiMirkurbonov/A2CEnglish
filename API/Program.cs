using API.Extensions;
using API.Middlewares;
using Database.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddServices(builder.Configuration)
    .AddControllers();

builder.Services.AddSwagger();

#pragma warning disable EXTEXP0018
builder.Services.AddHybridCache();
#pragma warning restore EXTEXP0018

builder.Services.AddAuthorizationSettings(builder.Configuration);

builder.Services.AddHandlerForBadRequest();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI();
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<PermissionSeeder>();
    seeder.SeedPermissions();
}

app
    .UseAuthentication()
    .UseAuthorization();

app.UseMiddleware<PermissionCheckerMiddleware>();

app.Run();