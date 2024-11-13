using System.Net;

namespace WeatherData.Exception.ExceptionBase;

public class RequestException : WeatherDataException
{

    public RequestException(string message) : base(message)
    { }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    
    public override List<string> GetErrors()
    {
        return [Message];
    }
}
