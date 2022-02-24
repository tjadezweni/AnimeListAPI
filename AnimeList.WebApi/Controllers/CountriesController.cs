using AnimeList.Application.Countries;
using AnimeList.Domain.Countries;
using Microsoft.AspNetCore.Mvc;


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

    [HttpGet]
    [ProducesResponseType(typeof(Country), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var countriesList = await countryService.Get();
        return Ok(countriesList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var country = await countryService.GetById(id);
        return Ok(country);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Country newCountry)
    {
        newCountry = await countryService.Create(newCountry);
        return Ok(newCountry);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Country), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Country updatedCountry)
    {
        updatedCountry.Id = id;
        updatedCountry = await countryService.Update(updatedCountry);
        return Ok(updatedCountry);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        await countryService.Delete(id);
        return NoContent();
    }
}
