using WeatherData.Domain.Entities;

namespace WeatherData.Domain.Services;

public interface IWeatherService
{
    Task<Stat> GetWeatherForecast(string city);
}
