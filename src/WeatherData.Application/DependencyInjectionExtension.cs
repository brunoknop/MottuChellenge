using Microsoft.Extensions.DependencyInjection;
using WeatherData.Application.UseCases;

namespace WeatherData.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGetCurrentTemperatureUseCase, GetCurrentTemperatureUseCase>();
    }
}
