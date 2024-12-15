using API.Extensions;

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
app.Run();