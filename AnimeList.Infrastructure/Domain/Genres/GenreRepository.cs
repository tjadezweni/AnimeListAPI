using AnimeList.Domain.Genres;
using AnimeList.Infrastructure.Database.Context;
using AnimeList.Infrastructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Domain.Genres;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(AnimeListContext context)
        : base(context) { }
}
