using AnimeListAPI.Domain.Interfaces;
using AnimeListAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AnimeListAPIContext _dbContext;

    public ICountryRepository _countryRepository { get; }
    public IGenreRepository _genreRepository { get; }
    public ILanguageRepository _languageRepository { get; }
    public IMovieRepository _movieRepository { get; }
    public ISeriesRepository _seriesRepository { get; }
    public IStudioRepository _studioRepository { get; }

    public IUserRepository _userRepository { get; }

    public UnitOfWork(
        ICountryRepository countryRepository,
        IGenreRepository genreRepository,
        ILanguageRepository languageRepository,
        IMovieRepository movieRepository,
        ISeriesRepository seriesRepository,
        IStudioRepository studioRepository,
        IUserRepository userRepository,
        AnimeListAPIContext dbContext)
    {
        _dbContext = dbContext;
        _countryRepository = countryRepository;
        _genreRepository = genreRepository;
        _languageRepository = languageRepository;
        _movieRepository = movieRepository;
        _seriesRepository = seriesRepository;
        _studioRepository = studioRepository;
        _userRepository = userRepository;
    }

    public Task SaveAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}
