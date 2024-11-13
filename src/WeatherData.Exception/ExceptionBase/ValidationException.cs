using System.Net;

namespace WeatherData.Exception.ExceptionBase;

public class RequestValidationException : WeatherDataException
{
    public RequestValidationException(string message) : base(message)
    { }
    
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
