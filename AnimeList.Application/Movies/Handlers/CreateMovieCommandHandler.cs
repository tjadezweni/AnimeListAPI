using AnimeList.Application.Movies.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Countries;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Movies.Handlers;


public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
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
        var newMovie = new Movie(request.Title, request.Description, request.YearReleased,
            request.GenreId, request.StudioId, request.LanguageId, request.CountryId)
        {
            Genre = genre,
            Language = language,
            Country = country,
            Studio = studio
        };
        await _unitOfWork.Movies.CreateAsync(newMovie);
        await _unitOfWork.SaveAsync();
        return newMovie;
    }
}
