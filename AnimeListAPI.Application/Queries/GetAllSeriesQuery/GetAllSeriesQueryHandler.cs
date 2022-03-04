using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetAllSeriesQuery;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllSeriesQuery, List<Series>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Series>> Handle(GetAllSeriesQuery request, CancellationToken cancellationToken)
    {
        var seriesList = await _unitOfWork._seriesRepository.ListAsync(series => true);
        return seriesList;
    }
}