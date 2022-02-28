using AnimeList.Application.Countries.Queries;
using AnimeList.Domain.Common;
using AnimeList.Domain.Countries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries.Handlers;

public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<Country>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCountriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Country>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        var countriesList = await _unitOfWork.Countries.GetAsync();
        return countriesList;
    }
}
