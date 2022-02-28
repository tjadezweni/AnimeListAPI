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

public class CreateSeriesCommandHandler : IRequestHandler<CreateSeriesCommand, Series>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Series> Handle(CreateSeriesCommand request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.Genres.GetByIdAsync(request.GenreId);
        if (genre is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Genre));
        }
        var language = await _unitOfWork.Languages.GetByIdAsync(request.LanguageId);
        if (language is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Language));
        }
        var country = await _unitOfWork.Countries.GetByIdAsync(request.CountryId);
        if (country is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Country));
        }
        var studio = await _unitOfWork.Studios.GetByIdAsync(request.StudioId);
        if (studio is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Studio));
        }
        var newSeries = new Series(request.Title, request.Description, request.Seasons,
            request.Episodes, request.IsCompleted, request.YearStarted, request.YearEnded,
            request.GenreId, request.StudioId, request.LanguageId, request.CountryId)
        {
            Genre = genre,
            Language = language,
            Country = country,
            Studio = studio
        };
        await _unitOfWork.Series.CreateAsync(newSeries);
        await _unitOfWork.SaveAsync();
        return newSeries;
    }
}
