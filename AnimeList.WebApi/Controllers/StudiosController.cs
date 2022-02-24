using AnimeList.Application.Studios;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Studios;
using Microsoft.AspNetCore.Mvc;


namespace AnimeList.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudiosController : ControllerBase
{
    private readonly IStudioService studioService;

    public StudiosController(IStudioService studiosService)
    {
        this.studioService = studiosService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Studio), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var studio = await studioService.GetById(id);
        return Ok(studio);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Studio>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var studiosList = await studioService.Get();
        return Ok(studiosList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Studio), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Studio newStudio)
    {
        await studioService.Create(newStudio);
        return Created("", newStudio);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Studio), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Studio updatedStudio)
    {
        updatedStudio.Id = id;
        updatedStudio = await studioService.Update(updatedStudio);
        return Ok(updatedStudio);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await studioService.Delete(id);
        return NoContent();
    }
}
