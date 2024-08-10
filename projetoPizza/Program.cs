using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using projetoPizza.Configuration;
using projetoPizza.Controllers;
using projetoPizza.Domain.Config;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddJsonFile("appsettings.Development.json", true).AddEnvironmentVariables();
builder.Services.Configure<SystemConfiguration>(builder.Configuration);
builder.Services.ConfigureDependencyInjection();
builder.Services.Configure<JsonSerializerSettings>(options =>
{
    options.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.Converters.Add(
        new StringEnumConverter
        {
            NamingStrategy = new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy()
        });
});
ServicePointManager.DefaultConnectionLimit = 500;
var app = builder.Build();

app.Services.GetRequiredService<PeopleController>().Map(app);
app.Services.GetRequiredService<PeopleDataController>().Map(app);

await app.RunAsync();