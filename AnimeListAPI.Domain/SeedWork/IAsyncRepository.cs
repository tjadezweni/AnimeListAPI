using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.SeedWork;

public interface IAsyncRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);

    Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression);

    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<bool> DeleteAsync(TEntity entity);
}
