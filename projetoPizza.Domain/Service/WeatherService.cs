using projetoPizza.Domain.Interface;
using projetoPizza.Domain.Model;

namespace projetoPizza.Domain.Service;
public class WeatherService : IWeatherService
{
    private readonly string[] Summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
    public WeatherForecastV1[] Getv1()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecastV1
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
                .ToArray();
        return forecast;
    }

    public WeatherForecastV2 Getv2()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecastV2
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
                .First();
        return forecast;
    }
}
