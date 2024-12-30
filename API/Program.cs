using API.Extensions;
using Database.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

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

app.Run();