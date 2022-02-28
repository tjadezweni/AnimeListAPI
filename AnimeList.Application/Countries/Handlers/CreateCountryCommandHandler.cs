using AnimeList.Application.Countries.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Countries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries.Handlers;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Country>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCountryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var name = request.Name;
        var newCountry = new Country(name);
        await _unitOfWork.Countries.CreateAsync(newCountry);
        await _unitOfWork.SaveAsync();
        return newCountry;
    }
}
