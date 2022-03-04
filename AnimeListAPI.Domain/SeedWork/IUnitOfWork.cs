using AnimeListAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.SeedWork;

public interface IUnitOfWork
{
    public ICountryRepository _countryRepository { get; }
    public IGenreRepository _genreRepository { get; }
    public ILanguageRepository _languageRepository { get; }
    public IMovieRepository _movieRepository { get; }
    public ISeriesRepository _seriesRepository { get; }
    public IStudioRepository _studioRepository { get; }


    Task SaveAsync();
}
