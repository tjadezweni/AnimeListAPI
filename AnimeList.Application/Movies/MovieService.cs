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
