using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateSeries;

public class UpdateSeriesCommandHandler : IRequestHandler<UpdateSeriesCommand, Series>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Series> Handle(UpdateSeriesCommand request, CancellationToken cancellationToken)
    {
        var id = request.Series.SeriesId;
        var existingSeries = await _unitOfWork._seriesRepository.GetAsync(series => series.SeriesId == id);
        if (existingSeries is null)
        {
            throw new SeriesNotFoundException();
        }
        var series = request.Series;
        await _unitOfWork._seriesRepository.UpdateAsync(series);
        await _unitOfWork.SaveAsync();
        return series;
    }
}