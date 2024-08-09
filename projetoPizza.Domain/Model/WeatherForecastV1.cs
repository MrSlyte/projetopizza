namespace projetoPizza.Domain.Model;

public readonly record struct WeatherForecastV1(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
