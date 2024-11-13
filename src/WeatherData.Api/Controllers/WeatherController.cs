using Microsoft.AspNetCore.Mvc;
using WeatherData.Application.UseCases;
using WeatherData.Communication.Request.Weather;
using WeatherData.Communication.Response;
using WeatherData.Communication.Response.Weather;

namespace WeatherData.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseGetCurrentTemperatureJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCurrentTemperature([FromQuery] RequestGetCurrentTemperatureJson request, [FromServices] IGetCurrentTemperatureUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }
    
}
