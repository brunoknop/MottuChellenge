using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WeatherData.Communication.Response;
using WeatherData.Exception;
using WeatherData.Exception.ExceptionBase;

namespace WeatherData.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is WeatherDataException)
            HandleProjectException(context);
        else
            ThrowUnknowError(context);
    }
    
    private void HandleProjectException(ExceptionContext context)
    {
        var weatherDataException = (WeatherDataException)context.Exception;
        var errorResponse = new ResponseErrorJson(weatherDataException.GetErrors());

        context.HttpContext.Response.StatusCode = weatherDataException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOW_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
