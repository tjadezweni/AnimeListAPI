using AnimeListAPI.Application.Commands.CreateLanguage;
using AnimeListAPI.Application.Commands.DeleteLanguage;
using AnimeListAPI.Application.Commands.UpdateLanguage;
using AnimeListAPI.Application.Queries.GetAllLanguages;
using AnimeListAPI.Application.Queries.GetLanguageById;
using AnimeListAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class LanguagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LanguagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Language), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetLanguageByIdQuery()
        {
            Id = id
        };
        var language = await _mediator.Send(query);
        return Ok(language);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Language>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllLanguagesQuery();
        var languageList = await _mediator.Send(query);
        return Ok(languageList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Language), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Language language)
    {
        var command = new CreateLanguageCommand()
        {
            Language = language
        };
        var newLanguage = await _mediator.Send(command);
        return Created("GetById", newLanguage);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Language), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] Language language)
    {
        var command = new UpdateLanguageCommand()
        {
            Language = language
        };
        var updatedLanguage = await _mediator.Send(command);
        return Ok(updatedLanguage);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteLanguageCommand()
        {
            Id = id
        };
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
