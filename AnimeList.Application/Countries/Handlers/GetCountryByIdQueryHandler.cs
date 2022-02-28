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

public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Country?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCountryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Country?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        return country;
    }
}
