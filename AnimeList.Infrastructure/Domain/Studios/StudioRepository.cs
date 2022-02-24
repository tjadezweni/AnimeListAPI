using AnimeList.Domain.Studios;
using AnimeList.Infrastructure.Database.Context;
using AnimeList.Infrastructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Domain.Studios;

public class StudioRepository : GenericRepository<Studio>, IStudioRepository
{
    public StudioRepository(AnimeListContext context)
        : base(context) { }
}
