using AnimeListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeListAPI.Repositories.Implementations;

public class RepositoryBase<T, K> : IRepositoryBase<T, K>
    where T : class
    where K : System.IComparable<K>
{
    private readonly DataContext dataContext;
    private readonly DbSet<T> dbSet;

    public RepositoryBase(DataContext dataContext)
    {
        this.dataContext = dataContext;
        dbSet = dataContext.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(K id)
    {
        var entity = await GetAsync(id);
        dbSet.Remove(entity!);
        await dataContext.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await dbSet.AsNoTracking()
            .ToListAsync();
    }

    public async Task<T?> GetAsync(K id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        dbSet.Update(entity);
        await dataContext.SaveChangesAsync();
    }
}
