using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(AnimeListAPIContext dbContext)
        : base(dbContext)
    {

    }
}
