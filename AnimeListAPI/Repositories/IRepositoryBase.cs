namespace AnimeListAPI.Repositories;

public interface IRepositoryBase<T, K> 
    where T : class
    where K : System.IComparable<K>
{
    Task<T?> GetAsync(K id);

    Task<List<T>> GetAllAsync();

    Task CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(K id);
}
