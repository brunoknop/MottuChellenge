using System.Net;

namespace WeatherData.Exception.ExceptionBase;

public class NotFoundException : WeatherDataException
{
    public NotFoundException(string message) : base(message)
    { }

    public override int StatusCode => (int)HttpStatusCode.NotFound;
    
    public override List<string> GetErrors()
    {
        return [Message];
    }
}
