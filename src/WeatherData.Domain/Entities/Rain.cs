using System.Text.Json.Serialization;

namespace WeatherData.Domain.Entities;

public class Rain
{
    [JsonPropertyName("1h")]
    public float ByHour { get; set; }
}
