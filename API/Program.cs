using API.Extensions;
using Database.Helpers;
using Microsoft.Extensions.Caching.Hybrid;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

#pragma warning disable EXTEXP0018
builder.Services.AddHybridCache(); 
#pragma warning restore EXTEXP0018

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