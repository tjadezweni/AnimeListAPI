using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.CreateCountry;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Country>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCountryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var newCountry = request.Country;
        await _unitOfWork._countryRepository.AddAsync(newCountry);
        await _unitOfWork.SaveAsync();
        return newCountry;
    }
}
