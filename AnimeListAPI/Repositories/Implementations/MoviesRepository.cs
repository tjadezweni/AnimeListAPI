using AnimeListAPI.Models;

namespace AnimeListAPI.Repositories.Implementations;

public class MoviesRepository : RepositoryBase<Movie, Guid>, IMoviesRepository
{
    public MoviesRepository(DataContext dataContext)
        : base(dataContext) { }
}
