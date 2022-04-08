using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteSeries;

public class DeleteSeriesCommandHandler : IRequestHandler<DeleteSeriesCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteSeriesCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var series = await _unitOfWork._seriesRepository.GetAsync(series => series.SeriesId == id);
        if (series is null)
        {
            throw new SeriesNotFoundException();
        }
        await _unitOfWork._seriesRepository.DeleteAsync(series);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
