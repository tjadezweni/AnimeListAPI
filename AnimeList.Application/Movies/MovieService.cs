using AnimeList.Domain.Common;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Movies;

public class MovieService : IMovieService
{
    private readonly IUnitOfWork unitOfWork;

    public MovieService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Movie> Create(Movie newMovie)
    {
        var genre = await unitOfWork.Genres.GetByIdAsync(newMovie.GenreId);
        if (genre is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Genre));
        }
        var language = await unitOfWork.Languages.GetByIdAsync(newMovie.LanguageId);
        if (language is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Language));
        }
        var country = await unitOfWork.Countries.GetByIdAsync(newMovie.CountryId);
        if (country is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Country));
        }
        var studio = await unitOfWork.Studio.GetByIdAsync(newMovie.StudioId);
        if (studio is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Studio));
        }
        newMovie.Genre = genre;
        newMovie.Language = language;
        newMovie.Country = country;
        newMovie.Studio = studio;
        await unitOfWork.Movies.CreateAsync(newMovie);
        await unitOfWork.SaveAsync();
        return newMovie;
    }

    public async Task Delete(int id)
    {
        await unitOfWork.Movies.DeleteAsync(id);
        await unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<Movie>> Get()
    {
        return await unitOfWork.Movies.GetAsync();
    }

    public async Task<Movie?> GetById(int id)
    {
        return await unitOfWork.Movies.GetByIdAsync(id);
    }

    public async Task<Movie> Update(Movie updatedMovie)
    {
        await unitOfWork.Movies.UpdateAsync(updatedMovie);
        await unitOfWork.SaveAsync();
        return updatedMovie;
    }
}
