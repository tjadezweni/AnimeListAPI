using AnimeList.Application.Serieses.Queries;
using AnimeList.Domain.Common;
using AnimeList.Domain.Serieses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Serieses.Handlers;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllSeriesQuery, IEnumerable<Series>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Series>> Handle(GetAllSeriesQuery request, CancellationToken cancellationToken)
    {
        var seriesList = await _unitOfWork.Series.GetAsync();
        return seriesList;
    }
}
