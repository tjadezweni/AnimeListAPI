using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetSeriesById;

public class GetSeriesByIdQueryHandler : IRequestHandler<GetSeriesByIdQuery, Series?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSeriesByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Series?> Handle(GetSeriesByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var series = await _unitOfWork._seriesRepository.GetAsync(series => series.SeriesId == id);
        return series;
    }
}