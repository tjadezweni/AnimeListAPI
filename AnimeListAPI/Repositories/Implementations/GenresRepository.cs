using AnimeListAPI.Models;

namespace AnimeListAPI.Repositories.Implementations;

public class GenresRepository : RepositoryBase<Genre, Guid>, IGenresRepository
{
    private readonly DataContext dataContext;
    public GenresRepository(DataContext dataContext)
        : base(dataContext)
    {
        this.dataContext = dataContext;
    }
}
