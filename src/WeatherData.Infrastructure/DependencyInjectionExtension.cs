using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherData.Domain.Services;
using WeatherData.Infrastructure.Services;

namespace WeatherData.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IWeatherService, WeatherService>();
    }
}
