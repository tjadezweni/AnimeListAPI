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
        var existingSeries = await unitOfWork.Series.GetByIdAsync(newSeries.Id);
        if (existingSeries is not null)
        {
            throw new Exception(ErrorMessages.IdFound(ModelType.Series));
        }
        var series = new Series()
        {
            Id = newSeries.Id,
            Title = newSeries.Title,
            Seasons = newSeries.Seasons,
            Episodes = newSeries.Episodes,
            IsCompleted = newSeries.IsCompleted,
            YearStarted = newSeries.YearStarted,
            YearEnded = newSeries.YearEnded,
            GenreId = newSeries.GenreId,
            CountryId = newSeries.CountryId,
            LanguageId = newSeries.LanguageId,
            StudioId = newSeries.StudioId,
        };
        await unitOfWork.Series.CreateAsync(series);
        await unitOfWork.SaveAsync();
        return series;
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
