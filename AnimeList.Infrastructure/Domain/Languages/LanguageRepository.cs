using AnimeList.Domain.Languages;
using AnimeList.Infrastructure.Database.Context;
using AnimeList.Infrastructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Domain.Languages;

public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
{
    public LanguageRepository(AnimeListContext context)
        : base(context) { }
}
