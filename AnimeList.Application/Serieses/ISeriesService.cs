using AnimeList.Domain.Serieses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Serieses;

public interface ISeriesService
{
    Task<Series?> GetById(int id);
    Task<IEnumerable<Series>> Get();
    Task<Series> Create(Series newSeries);
    Task<Series> Update(Series updatedSeries);
    Task Delete(int id);

}
