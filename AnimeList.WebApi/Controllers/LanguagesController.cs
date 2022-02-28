using AnimeList.Application.Languages;
using AnimeList.Application.Languages.Commands;
using AnimeList.Application.Languages.Queries;
using AnimeList.Domain.Languages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
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
        var query = new GetLanguageByIdQuery(id);
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
    public async Task<IActionResult> Create([FromBody] CreateLanguageCommand request)
    {
        var newLanguage = await _mediator.Send(request);
        return Created("GetById", newLanguage);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Language), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateLanguageCommand request)
    {
        request.Id = id;
        var updatedLanguage = await _mediator.Send(request);
        return Ok(updatedLanguage);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteLanguageCommand(id);
        _ = await _mediator.Send(query);
        return NoContent();
    }
}
