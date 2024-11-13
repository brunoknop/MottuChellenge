using WeatherData.Communication.Request.Weather;
using WeatherData.Communication.Response.Weather;

namespace WeatherData.Application.UseCases;

public interface IGetCurrentTemperatureUseCase
{
    Task<ResponseGetCurrentTemperatureJson> Execute(RequestGetCurrentTemperatureJson request);
}
