using AnimeList.Application.Movies.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Movies.Handlers;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Movie>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Movie> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var existingMovie = await _unitOfWork.Movies.GetByIdAsync(request.Id);
        if (existingMovie is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Movie));
        }
        existingMovie.Title = request.Title;
        existingMovie.Description = request.Description;
        existingMovie.YearReleased = request.YearReleased;
        existingMovie.GenreId = request.GenreId;
        existingMovie.StudioId = request.StudioId;
        existingMovie.LanguageId = request.LanguageId;
        existingMovie.CountryId = request.CountryId;
        await _unitOfWork.Movies.UpdateAsync(existingMovie);
        await _unitOfWork.SaveAsync();
        return existingMovie;
    }
}
