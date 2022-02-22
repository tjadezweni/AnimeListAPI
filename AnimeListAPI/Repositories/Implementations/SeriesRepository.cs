using AnimeListAPI.Models;

namespace AnimeListAPI.Repositories.Implementations;

public class SeriesRepository : RepositoryBase<Series, Guid>, ISeriesRepository
{
    public SeriesRepository(DataContext dataContext)
        : base(dataContext) { }
}
