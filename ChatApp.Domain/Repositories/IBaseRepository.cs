using System.Linq.Expressions;

namespace ChatApp.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

    Task<TEntity> SaveAsync(TEntity entity);

    ValueTask<TEntity?> GetByIdAsync(Guid id);

    Task RemoveAsync(TEntity entity);
}