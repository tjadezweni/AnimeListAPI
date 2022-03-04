using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.CreateSeries;

public class CreateSeriesCommandHandler : IRequestHandler<CreateSeriesCommand, Series>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Series> Handle(CreateSeriesCommand request, CancellationToken cancellationToken)
    {
        var genreId = request.Series.GenreId;
        var languageId = request.Series.LanguageId;
        var studioId = request.Series.StudioId;
        var countryId = request.Series.CountryId;
        var genre = await _unitOfWork._genreRepository.GetAsync(genre => genre.GenreId == genreId);
        if (genre is null)
        {
            throw new GenreNotFoundException();
        }
        var language = await _unitOfWork._languageRepository.GetAsync(language => language.LanguageId == languageId);
        if (language is null)
        {
            throw new LanguageNotFoundException();
        }
        var country = await _unitOfWork._countryRepository.GetAsync(country => country.CountryId == countryId);
        if (country is null)
        {
            throw new CountryNotFoundException();
        }
        var studio = await _unitOfWork._studioRepository.GetAsync(studio => studio.StudioId == studioId);
        if (studio is null)
        {
            throw new StudioNotFoundException();
        }
        var newSeries = request.Series;
        newSeries.Genre = genre;
        newSeries.Language = language;
        newSeries.Country = country;
        newSeries.Studio = studio;
        await _unitOfWork._seriesRepository.AddAsync(newSeries);
        await _unitOfWork.SaveAsync();
        return newSeries;
    }
}
