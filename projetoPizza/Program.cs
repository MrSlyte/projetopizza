using projetoPizza.Configuration;
using projetoPizza.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureDependencyInjection();

var app = builder.Build();

app.Services.GetRequiredService<LoginController>().Map(app);

if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

app.Run();