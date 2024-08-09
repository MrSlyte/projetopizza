using projetoPizza.Domain.Model;

namespace projetoPizza.Domain.Interface;
public interface IWeatherService
{
    WeatherForecastV1[] Getv1();
    WeatherForecastV2 Getv2();
}