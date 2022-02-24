using AnimeList.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Domain.Movies;

public interface IMovieRepository : IGenericRepository<Movie>
{
}
