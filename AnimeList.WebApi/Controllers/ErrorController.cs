using AnimeList.Domain.Helpers;
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

            switch (exception)
            {
                case ApiException:
                    logger.LogInformation($"{DateTime.UtcNow} : {message} : {stackTrace}");
                    break;
                default:
                    logger.LogError($"{DateTime.UtcNow} : {message} : {stackTrace}");
                    break;
            }
            return Problem(statusCode: 500, detail: "An error occurred");
        }
        catch (Exception exception)
        {
            logger.LogError($"{DateTime.UtcNow} : {exception.Message} : {exception.StackTrace}");
            return Problem(statusCode: 500, detail: "An error occured");
        }
    }
}
