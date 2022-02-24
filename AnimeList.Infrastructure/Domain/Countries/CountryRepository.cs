using AnimeList.Domain.Countries;
using AnimeList.Infrastructure.Database.Context;
using AnimeList.Infrastructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Domain.Countries;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(AnimeListContext context)
        : base(context)
    { }
}
