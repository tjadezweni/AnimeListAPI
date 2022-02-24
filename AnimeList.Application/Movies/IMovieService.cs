using AnimeList.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Movies;

public interface IMovieService
{
    Task<Movie?> GetById(int id);
    Task<IEnumerable<Movie>> Get();
    Task<Movie> Create(Movie newMovies);
    Task<Movie> Update(Movie updatedMovies);
    Task Delete(int id);
}
