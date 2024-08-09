namespace projetoPizza.Domain.Model;

public readonly record struct WeatherForecastV2(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
