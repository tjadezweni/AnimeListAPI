using AnimeListAPI.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ErrorController : ControllerBase
{
    private readonly ILogger<ErrorController> logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        this.logger = logger;
    }

    [HttpGet("/error")]
    public IActionResult Error()
    {
        try
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context!.Error;
            var message = exception!.Message;
            var stackTrace = exception!.StackTrace;
            var statusCode = StatusCodes.Status500InternalServerError;

            switch (exception)
            {
                case ApiException:
                    logger.LogInformation($"{DateTime.UtcNow} : {message} : {stackTrace}");
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                default:
                    logger.LogCritical($"{DateTime.UtcNow} : {message} : {stackTrace}");
                    break;
            }
            return Problem(statusCode: statusCode, detail: "An error occurred");
        }
        catch (Exception exception)
        {
            logger.LogError($"{DateTime.UtcNow} : {exception.Message} : {exception.StackTrace}");
            return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "An error occured");
        }
    }
}
