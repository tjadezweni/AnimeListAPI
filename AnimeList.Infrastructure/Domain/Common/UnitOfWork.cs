using AnimeList.Domain.Common;
using AnimeList.Domain.Countries;
using AnimeList.Domain.Genres;
using AnimeList.Domain.Languages;
using AnimeList.Domain.Movies;
using AnimeList.Domain.Serieses;
using AnimeList.Domain.Studios;
using AnimeList.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Domain.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly AnimeListContext context;
    public ICountryRepository Countries { get; private set; }

    public IGenreRepository Genres { get; private set; }

    public ILanguageRepository Languages { get; private set; }

    public IMovieRepository Movies { get; private set; }

    public ISeriesRepository Series { get; private set; }

    public IStudioRepository Studio { get; private set; }

    public UnitOfWork(
        AnimeListContext context,
        ICountryRepository countryRepository,
        IGenreRepository genreRepository,
        ILanguageRepository languageRepository,
        IMovieRepository movieRepository,
        ISeriesRepository seriesRepository,
        IStudioRepository studioRepository)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
        Countries = countryRepository;
        Genres = genreRepository;
        Languages = languageRepository;
        Movies = movieRepository;
        Series = seriesRepository;
        Studio = studioRepository;
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}
