using AnimeList.Application.Countries;
using AnimeList.Application.Genres;
using AnimeList.Application.Languages;
using AnimeList.Application.Movies;
using AnimeList.Application.Serieses;
using AnimeList.Application.Studios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application;

public static class ApplicationServicesDI
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        #region Services
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<ISeriesService, SeriesService>();
        services.AddScoped<IStudioService, StudioService>();
        #endregion
    }
}
