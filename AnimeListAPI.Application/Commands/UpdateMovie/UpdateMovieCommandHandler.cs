using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateMovie;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Movie>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Movie> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var id = request.Movie.MovieId;
        var existingMovie = await _unitOfWork._movieRepository.GetAsync(movie => movie.MovieId == id);
        if (existingMovie is null)
        {
            throw new MovieNotFoundException();
        }
        var movie = request.Movie;
        existingMovie.Title = movie.Title;
        existingMovie.Description = movie.Description;
        existingMovie.YearReleased = movie.YearReleased;
        existingMovie.CountryId = movie.CountryId;
        existingMovie.GenreId = movie.GenreId;
        existingMovie.LanguageId = movie.LanguageId;
        existingMovie.StudioId = movie.StudioId;
        await _unitOfWork._movieRepository.UpdateAsync(existingMovie);
        await _unitOfWork.SaveAsync();
        return existingMovie;
    }
}
