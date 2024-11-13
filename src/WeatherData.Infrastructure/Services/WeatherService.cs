using Newtonsoft.Json;
using WeatherData.Domain.Entities;
using WeatherData.Domain.Services;
using WeatherData.Exception;
using WeatherData.Exception.ExceptionBase;

namespace WeatherData.Infrastructure.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly ExternalApiSettings _apiSettings;

    
    public WeatherService(
        HttpClient httpClient, 
        ExternalApiSettings apiSettings)
    {
        _httpClient = httpClient;
        _apiSettings = apiSettings;
    }
    public async Task<Stat> GetWeatherForecast(string city)
    {
        var response = await _httpClient.GetAsync($"{_apiSettings.BaseUrl}/weather?q={city}&units=metric&appid={_apiSettings.ApiKey}");

        if (!response.IsSuccessStatusCode)
        {
            
            throw (int)response.StatusCode == 404
                ? new NotFoundException(ResourceErrorMessages.CITY_NOT_FOUNT)
                : new RequestException(ResourceErrorMessages.UNKNOW_ERROR);
        }

        var json = await response.Content.ReadAsStringAsync();
        var retorno = JsonConvert.DeserializeObject<Stat>(json);

        return retorno;
    }
}
