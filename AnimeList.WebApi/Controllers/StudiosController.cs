using AnimeList.Application.Studios;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Studios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

    // GET: api/<SeriesController>/1
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

    // POST api/<SeriesController>
    [HttpPost]
    [ProducesResponseType(typeof(Studio), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Studio newStudio)
    {
        await studioService.Create(newStudio);
        return Created("", newStudio);
    }

    // PUT api/<SeriesController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Studio), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Studio updatedStudio)
    {
        updatedStudio.Id = id;
        updatedStudio = await studioService.Update(updatedStudio);
        return Ok(updatedStudio);
    }

    // DELETE api/<SeriesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await studioService.Delete(id);
        return NoContent();
    }
}
