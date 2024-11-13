namespace WeatherData.Exception.ExceptionBase;

public abstract class WeatherDataException : SystemException
{
    protected WeatherDataException(string message) : base(message)
    { }
    
    public abstract int StatusCode { get; }

    public abstract List<string> GetErrors();
}
