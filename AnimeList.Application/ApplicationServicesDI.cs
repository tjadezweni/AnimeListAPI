using AnimeList.Application.Countries;
using AnimeList.Application.Genres;
using AnimeList.Application.Languages;
using AnimeList.Application.Movies;
using AnimeList.Application.Serieses;
using AnimeList.Application.Studios;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        #region Mediator
        services.AddMediatR(Assembly.GetExecutingAssembly());
        #endregion
    }
}
