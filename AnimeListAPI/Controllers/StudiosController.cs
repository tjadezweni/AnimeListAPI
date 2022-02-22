using AnimeListAPI.Dto;
using AnimeListAPI.Models;
using AnimeListAPI.Repositories;
using AnimeListAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeListAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudiosController : ControllerBase
{
    private readonly IStudiosRepository studiosRepository;

    public StudiosController(IStudiosRepository studiosRepository)
    {
        this.studiosRepository = studiosRepository;
    }

    // GET: api/<StudiosController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var studiosList = await studiosRepository.GetAllAsync();
        return Ok(studiosList);
    }

    // GET api/<StudiosController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var studio = await studiosRepository.GetAsync(id);
        return Ok(studio);
    }

    // POST api/<StudiosController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudioDTO newStudio)
    {
        var existingStudio = await studiosRepository.GetAsync(newStudio.Id);
        if (existingStudio is not null)
        {
            return BadRequest(ErrorMessages.IdFound("studio"));
        }
        var studio = new Studio()
        {
            Id = newStudio.Id,
            Name = newStudio.Name,
        };
        await studiosRepository.CreateAsync(studio);
        return Created($"/api/Studios/{newStudio.Id}", newStudio);
    }

    // PUT api/<StudiosController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] StudioDTO updatedStudio)
    {
        var existingStudio = await studiosRepository.GetAsync(id);
        if (existingStudio is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("studio"));
        }
        existingStudio.Name = updatedStudio.Name;
        await studiosRepository.UpdateAsync(existingStudio);
        return Ok(existingStudio);
    }

    // DELETE api/<StudiosController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existingStudio = await studiosRepository.GetAsync(id);
        if (existingStudio is null)
        {
            return BadRequest(ErrorMessages.IdNotFound("studio"));
        }
        await studiosRepository.DeleteAsync(id);
        return NoContent();
    }
}
