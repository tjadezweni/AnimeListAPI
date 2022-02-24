using AnimeList.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries;

public interface ICountryService
{
    Task<Country?> GetById(int id);
    Task<IEnumerable<Country>> Get();
    Task<Country> Create(Country newCountry);
    Task<Country> Update(Country updatedCountry);
    Task Delete(int id);
}
