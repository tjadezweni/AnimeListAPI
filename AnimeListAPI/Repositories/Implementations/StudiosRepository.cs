using AnimeListAPI.Models;

namespace AnimeListAPI.Repositories.Implementations;

public class StudiosRepository : RepositoryBase<Studio, Guid>, IStudiosRepository
{
    private readonly DataContext dataContext;

    public StudiosRepository(DataContext dataContext)
        : base(dataContext)
    {
        this.dataContext = dataContext;
    }
}
