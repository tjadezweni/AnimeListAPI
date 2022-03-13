using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetAllCountries;

public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, List<Country>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCountriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Country>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        var countriesList = await _unitOfWork._countryRepository.ListAsync(country => true);
        return countriesList;
    }
}
