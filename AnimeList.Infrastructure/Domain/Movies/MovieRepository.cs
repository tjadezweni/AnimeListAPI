using AnimeList.Domain.Movies;
using AnimeList.Infrastructure.Database.Context;
using AnimeList.Infrastructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Domain.Movies;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(AnimeListContext context)
        : base(context) { }
}
