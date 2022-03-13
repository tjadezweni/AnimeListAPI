using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure.Repositories;

public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
{
    public LanguageRepository(AnimeListAPIContext dbContext)
        : base(dbContext)
    {

    }
}
