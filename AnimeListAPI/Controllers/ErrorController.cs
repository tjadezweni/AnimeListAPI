using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeListAPI.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    private readonly ILogger<ErrorController> logger;

    public ErrorController(ILogger<ErrorController> logger)
        : base()
    {
        this.logger = logger;
    }

    [HttpGet("/error")]
    public async Task<IActionResult> Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var stackTrace = context.Error.StackTrace;
        var errorMessage = context.Error.Message;

        logger.LogInformation($"{DateTime.Now} : {errorMessage} : {stackTrace}");

        return Problem(statusCode: 500, detail: "An error occurred");
    }
}
