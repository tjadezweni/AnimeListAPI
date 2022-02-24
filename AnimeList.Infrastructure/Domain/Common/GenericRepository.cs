using AnimeList.Domain.Common;
using AnimeList.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Domain.Common;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    protected readonly AnimeListContext dataContext;

    protected readonly DbSet<TEntity> dbSet;

    public GenericRepository(AnimeListContext dataContext)
    {
        this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        this.dbSet = dataContext.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task CreateRangeAsync(TEntity entities)
    {
        await dbSet.AddRangeAsync(entities);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await dbSet.FindAsync(id);
        dbSet.Remove(entity!);
    }

    public async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null, 
        Func<IQueryable<TEntity>, 
        IOrderedQueryable<TEntity>> orderBy = null)
    {
        IQueryable<TEntity> query = dbSet;
        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (orderBy is not null)
        {
            return orderBy(query).AsNoTracking()
                .ToList();
        }
        return query.AsNoTracking()
            .ToList();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        var entity = await dbSet.FindAsync(id);
       return entity;
    }

    public async Task UpdateAsync(TEntity entityToUpdate)
    {
        dbSet.Update(entityToUpdate);
    }
}
