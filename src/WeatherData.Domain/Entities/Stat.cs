namespace WeatherData.Domain.Entities;

public class Stat
{
    public Coordinates coord { get; set; }
    
    public List<Weather> weather { get; set; }
    
    public string Base { get; set; }
    
    public Main main { get; set; }
    
    public int Visibility { get; set; }
    
    public Wind Wind { get; set; }
    
    public Rain Rain { get; set; }
    
    public Clouds Clouds { get; set; }
    
    public long Dt { get; set; }
    
    public Sys Sys { get; set; }
    
    public int Timezone { get; set; }
    
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public int Cod { get; set; }
}
