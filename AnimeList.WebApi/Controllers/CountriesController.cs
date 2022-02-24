using AnimeList.Application.Countries;
using AnimeList.Domain.Countries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryService countryService;

    public CountriesController(ICountryService countryService)
    {
        this.countryService = countryService;
    }

    // GET: api/<CountriesController>
    [HttpGet]
    [ProducesResponseType(typeof(Country), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var countriesList = await countryService.Get();
        return Ok(countriesList);
    }

    // GET api/<CountriesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var country = await countryService.GetById(id);
        return Ok(country);
    }

    // POST api/<CountriesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Country newCountry)
    {
        newCountry = await countryService.Create(newCountry);
        return Ok(newCountry);
    }

    // PUT api/<CountriesController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Country), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Country updatedCountry)
    {
        updatedCountry.Id = id;
        updatedCountry = await countryService.Update(updatedCountry);
        return Ok(updatedCountry);
    }

    // DELETE api/<CountriesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await countryService.Delete(id);
        return NoContent();
    }
}
