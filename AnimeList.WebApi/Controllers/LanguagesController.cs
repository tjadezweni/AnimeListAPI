using AnimeList.Application.Languages;
using AnimeList.Domain.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService languageService;

    public LanguagesController(ILanguageService languageService)
    {
        this.languageService = languageService;
    }

    // GET: api/<SeriesController>/1
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Language), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var language = await languageService.GetById(id);
        return Ok(language);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Language>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var languagesList = await languageService.Get();
        return Ok(languagesList);
    }

    // POST api/<SeriesController>
    [HttpPost]
    [ProducesResponseType(typeof(Language), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Language newLanguage)
    {
        await languageService.Create(newLanguage);
        return Created("", newLanguage);
    }

    // PUT api/<SeriesController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Language), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Language updatedLanguage)
    {
        updatedLanguage.Id = id;
        updatedLanguage = await languageService.Update(updatedLanguage);
        return Ok(updatedLanguage);
    }

    // DELETE api/<SeriesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await languageService.Delete(id);
        return NoContent();
    }
}
