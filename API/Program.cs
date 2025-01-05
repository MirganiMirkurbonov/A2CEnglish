using API.Extensions;
using API.Middlewares;
using Database.Helpers;
using Domain.Extensions;
using Microsoft.Extensions.FileProviders;

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

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/admin/swagger.json", "admin");
        c.SwaggerEndpoint("/swagger/user/swagger.json", "user");
    });
}

app.MapControllers();

app.UseStaticFiles();

app.UseCors(policy =>
{
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<PermissionSeeder>();
    seeder.SeedPermissions();
    seeder.AddAllPermissionsToAdmin();
}

app
    .UseAuthentication()
    .UseAuthorization();

app.UseMiddleware<PermissionCheckerMiddleware>();

if (app.Services.GetService<IHttpContextAccessor>() != null)
{
    FileExtension.HttpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
    RequestPath = "/files"
});
app.Run();