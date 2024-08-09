using Microsoft.Extensions.Options;
using projetoPizza.Controllers;
using projetoPizza.Domain.Interface;
using projetoPizza.Domain.Service;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace projetoPizza.Configuration;
internal static class DependencyInjection
{
    internal static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddTransient<IWeatherService, WeatherService>();
        services.AddTransient<LoginController>();
    }
}