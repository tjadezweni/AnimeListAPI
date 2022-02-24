using AnimeList.Domain.Common;
using AnimeList.Domain.Countries;
using AnimeList.Domain.Genres;
using AnimeList.Domain.Languages;
using AnimeList.Domain.Movies;
using AnimeList.Domain.Serieses;
using AnimeList.Domain.Studios;
using AnimeList.Infrastructure.Database.Context;
using AnimeList.Infrastructure.Domain.Common;
using AnimeList.Infrastructure.Domain.Countries;
using AnimeList.Infrastructure.Domain.Genres;
using AnimeList.Infrastructure.Domain.Languages;
using AnimeList.Infrastructure.Domain.Movies;
using AnimeList.Infrastructure.Domain.Serieses;
using AnimeList.Infrastructure.Domain.Studios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure;

public static class InfrastructureServicesDI
{
    public static void RegisterInfrastructureServices(
        this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        #region Context
        services.AddDbContext<AnimeListContext>(options =>
        {
            options.UseInMemoryDatabase("AnimeList");
        });
        #endregion

        #region Repositories
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ISeriesRepository, SeriesRepository>();
        services.AddScoped<IStudioRepository, StudioRepository>();
        #endregion

        #region UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion
    }
}
