using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure.Repositories;

public class SeriesRepository : BaseRepository<Series>, ISeriesRepository
{
    public SeriesRepository(AnimeListAPIContext dbContext)
        : base(dbContext)
    {

    }
}
