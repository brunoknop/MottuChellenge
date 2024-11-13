using WeatherData.Communication.Request.Weather;
using WeatherData.Communication.Response.Weather;
using WeatherData.Domain.Services;
using WeatherData.Exception;
using WeatherData.Exception.ExceptionBase;

namespace WeatherData.Application.UseCases;

public class GetCurrentTemperatureUseCase : IGetCurrentTemperatureUseCase
{
    const float CELSIUS_TO_FAHRENHEIT_RATIO = 1.8f;
    const int FAHRENHEIT_FREEZING_POINT = 32;
    const float KELVIN_BASE = 273.15f;
    
    private readonly IWeatherService _weatherService;
    
    public GetCurrentTemperatureUseCase(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    
    public async Task<ResponseGetCurrentTemperatureJson> Execute(RequestGetCurrentTemperatureJson request)
    {
        Validate(request);
        
        var weather = await _weatherService.GetWeatherForecast(request.City);

        var fahrenheitConvertion = ((weather.main.Temp * CELSIUS_TO_FAHRENHEIT_RATIO) + FAHRENHEIT_FREEZING_POINT);
        var kelvinConvertion = weather.main.Temp + KELVIN_BASE;
        
        return new ResponseGetCurrentTemperatureJson()
        {
            Celsius = weather.main.Temp,
            Fahrenheit = fahrenheitConvertion,
            Kelvin = kelvinConvertion
        };
    }

    private void Validate(RequestGetCurrentTemperatureJson request)
    {
        if (string.IsNullOrWhiteSpace(request.City))
            throw new RequestValidationException(ResourceErrorMessages.CITY_EMPTY);
    }

}
