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
            LogErrorMessage(context!.Error);
            return Problem(statusCode: 500, detail: "An error occurred");
        }
        catch (Exception exception)
        {
            LogErrorMessage(exception);
            return Problem(statusCode: 500, detail: "An error occured");
        }
    }

    private void LogErrorMessage(Exception exception)
    {
        var errorMessage = exception.Message;
        var stackTrace = exception.StackTrace;
        logger.LogError($"{DateTime.UtcNow} : {errorMessage} : {stackTrace}");
    }
}
