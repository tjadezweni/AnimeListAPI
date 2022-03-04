using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.CreateMovie;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var genreId = request.Movie.GenreId;
        var langaugeId = request.Movie.LanguageId;
        var studioId = request.Movie.StudioId;
        var countryId = request.Movie.CountryId;
        var genre = await _unitOfWork._genreRepository.GetAsync(genre => genre.GenreId == genreId);
        if (genre is null)
        {
            throw new GenreNotFoundException();
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
        var language = await _unitOfWork._languageRepository.GetAsync(language => language.LanguageId == langaugeId);
        if (language is null)
        {
            throw new LanguageNotFoundException();
        }
        var newMovie = request.Movie;
        newMovie.Genre = genre;
        newMovie.Language = language;
        newMovie.Studio = studio;
        newMovie.Country = country;
        await _unitOfWork._movieRepository.AddAsync(newMovie);
        await _unitOfWork.SaveAsync();
        return newMovie;
    }
}
