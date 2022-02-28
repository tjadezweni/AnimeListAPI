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
        var series = await _unitOfWork.Series.GetByIdAsync(id);
        return series;
    }
}
