using AnimeList.Domain.Countries;
using AnimeList.Domain.Genres;
using AnimeList.Domain.Languages;
using AnimeList.Domain.Movies;
using AnimeList.Domain.Serieses;
using AnimeList.Domain.Studios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Domain.Common;

public interface IUnitOfWork
{
    #region Repositories
    ICountryRepository Countries { get; }
    IGenreRepository Genres { get; }
    ILanguageRepository Languages { get; }
    IMovieRepository Movies { get; }
    ISeriesRepository Series { get; }
    IStudioRepository Studio { get; }
    #endregion

    Task SaveAsync();
}
