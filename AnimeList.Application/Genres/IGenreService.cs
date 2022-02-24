using AnimeList.Domain.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Genres;

public interface IGenreService
{
    Task<Genre?> GetById(int id);
    Task<IEnumerable<Genre>> Get();
    Task<Genre> Create(Genre newGenre);
    Task<Genre> Update(Genre updatedGenre);
    Task Delete(int id);
}
