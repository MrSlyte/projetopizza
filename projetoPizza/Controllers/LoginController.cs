using projetoPizza.Domain;
using projetoPizza.Domain.Interface;

namespace projetoPizza.Controllers;

internal record LoginController(IWeatherService WeatherService)
{
    private const string VersionSetName = "Login";
    private const string GetRoute = "/api/v{version:apiVersion}/get";

    private readonly IWeatherService _weatherService = WeatherService;

    internal void Map(WebApplication app)
    {
        var login = app.NewApiVersionSet(VersionSetName).Build();
        app.MapGet(GetRoute, Getv1).Produces<WeatherForecastViewModelV1[]>()
        .Produces(200)
        .WithApiVersionSet(login)
        .HasApiVersion(1.0);

        app.MapGet(GetRoute, Getv2).Produces<WeatherForecastViewModelV2>()
        .Produces(200)
        .WithApiVersionSet(login)
        .AdvertisesDeprecatedApiVersion(1.0)
        .HasApiVersion(2.0);
    }

    private WeatherForecastViewModelV2 Getv2()
    {
        var result = _weatherService.Getv2();
        return new WeatherForecastViewModelV2(result.Date, result.TemperatureC, result.TemperatureF, result.Summary);
    }

    private IEnumerable<WeatherForecastViewModelV1> Getv1()
    {
        var result = _weatherService.Getv1();
        var list = from res in result
                    select new WeatherForecastViewModelV1(res.Date, res.TemperatureC, res.TemperatureF, res.Summary);
        return list;
    }
}