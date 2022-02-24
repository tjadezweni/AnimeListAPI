using AnimeList.Domain.Serieses;
using AnimeList.Infrastructure.Database.Context;
using AnimeList.Infrastructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Domain.Serieses;

public class SeriesRepository : GenericRepository<Series>, ISeriesRepository
{
    public SeriesRepository(AnimeListContext context)
        : base(context) { }
}
