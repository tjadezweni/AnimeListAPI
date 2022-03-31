using AnimeListAPI.Application.Commands.RegisterAccount;
using AnimeListAPI.Application.Dtos;
using AnimeListAPI.Application.Queries.LoginAccount;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAccount(AccountDto accountDto)
    {
        var command = new RegisterAccountCommand(accountDto);
        var token = await _mediator.Send(command);
        return Created("", token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAccount(AccountDto accountDto)
    {
        var command = new LoginAccountQuery(accountDto);
        var token = await _mediator.Send(command);
        return Ok(token);
    }
}
