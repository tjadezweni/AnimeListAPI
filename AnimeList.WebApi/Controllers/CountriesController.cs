using AnimeListAPI.Application.Commands.CreateCountry;
using AnimeListAPI.Application.Commands.DeleteCountry;
using AnimeListAPI.Application.Commands.UpdateCountry;
using AnimeListAPI.Application.Queries.GetAllCountries;
using AnimeListAPI.Application.Queries.GetCountryById;
using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AnimeList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CountriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly AnimeListAPIContext _context;

    public CountriesController(IMediator mediator, AnimeListAPIContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Country), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCountriesQuery();
        var countries = await _mediator.Send(query);
        return Ok(countries);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(List<Country>), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetCountryByIdQuery()
        {
            Id = id
        };
        var country = await _mediator.Send(query);
        return country is null ? NotFound() : Ok(country);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Country), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Country country)
    {
        var command = new CreateCountryCommand()
        {
            Country = country
        };
        var newCountry = await _mediator.Send(command);
        return Created("GetById", newCountry);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Country), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] Country country)
    {
        var command = new UpdateCountryCommand()
        {
            country = country
        };
        var updatedCountry = await _mediator.Send(command);
        return Ok(updatedCountry);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteCountryCommand()
        {
            Id = id
        };
        _ = await _mediator.Send(query);
        return NoContent();
    }
}