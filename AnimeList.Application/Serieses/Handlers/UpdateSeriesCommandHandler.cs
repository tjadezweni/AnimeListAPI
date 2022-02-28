using AnimeList.Application.Serieses.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Serieses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Serieses.Handlers;

public class UpdateSeriesCommandHandler : IRequestHandler<UpdateSeriesCommand, Series>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Series> Handle(UpdateSeriesCommand request, CancellationToken cancellationToken)
    {
        var existingSeries = await _unitOfWork.Series.GetByIdAsync(request.Id);
        if (existingSeries is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Movie));
        }
        existingSeries.Title = request.Title;
        existingSeries.Description = request.Description;
        existingSeries.Seasons = request.Seasons;
        existingSeries.Episodes = request.Episodes;
        existingSeries.YearStarted = request.YearStarted;
        existingSeries.YearEnded = request.YearEnded;
        existingSeries.GenreId = request.GenreId;
        existingSeries.StudioId = request.StudioId;
        existingSeries.LanguageId = request.LanguageId;
        existingSeries.CountryId = request.CountryId;
        await _unitOfWork.Series.UpdateAsync(existingSeries);
        await _unitOfWork.SaveAsync();
        return existingSeries;
    }
}
