using AnimeList.Domain.Common;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Serieses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Serieses;

public class SeriesService : ISeriesService
{
    private readonly IUnitOfWork unitOfWork;

    public SeriesService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Series> Create(Series newSeries)
    {
        var genre = await unitOfWork.Genres.GetByIdAsync(newSeries.GenreId);
        if (genre is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Genre));
        }
        var language = await unitOfWork.Languages.GetByIdAsync(newSeries.LanguageId);
        if (language is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Language));
        }
        var country = await unitOfWork.Countries.GetByIdAsync(newSeries.CountryId);
        if (country is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Country));
        }
        var studio = await unitOfWork.Studio.GetByIdAsync(newSeries.StudioId);
        if (studio is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Studio));
        }
        newSeries.Genre = genre;
        newSeries.Language = language;
        newSeries.Country = country;
        newSeries.Studio = studio;
        await unitOfWork.Series.CreateAsync(newSeries);
        await unitOfWork.SaveAsync();
        return newSeries;
    }

    public async Task Delete(int id)
    {
        await unitOfWork.Series.DeleteAsync(id);
        await unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<Series>> Get()
    {
        return await unitOfWork.Series.GetAsync();
    }

    public async Task<Series?> GetById(int id)
    {
        return await unitOfWork.Series.GetByIdAsync(id);
    }

    public async Task<Series> Update(Series updatedSeries)
    {
        await unitOfWork.Series.UpdateAsync(updatedSeries);
        await unitOfWork.SaveAsync();
        return updatedSeries;
    }
}
