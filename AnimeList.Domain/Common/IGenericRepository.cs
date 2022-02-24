using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Domain.Common;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task<TEntity?> GetByIdAsync(int id);

    Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null!,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!);

    Task CreateAsync(TEntity entity);

    Task CreateRangeAsync(TEntity entities);

    Task UpdateAsync(TEntity entityToUpdate);

    Task DeleteAsync(int id);
}
