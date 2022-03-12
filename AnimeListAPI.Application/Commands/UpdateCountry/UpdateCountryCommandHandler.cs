using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateCountry;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCountryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var id = request.country.CountryId;
        var existingCountry = await _unitOfWork._countryRepository.GetAsync(country => country.CountryId == id);
        if (existingCountry is null)
        {
            throw new CountryNotFoundException();
        }
        existingCountry.Name = request.country.Name;
        await _unitOfWork._countryRepository.UpdateAsync(existingCountry);
        await _unitOfWork.SaveAsync();
        return existingCountry;
    }
}
