using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure.Repositories;

public class StudioRepository : BaseRepository<Studio>, IStudioRepository
{
    public StudioRepository(AnimeListAPIContext dbContext)
        : base(dbContext)
    {

    }
}
