using System.Linq.Expressions;

namespace ChatApp.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> expression);



    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task AddAsync(TEntity entity);


    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}