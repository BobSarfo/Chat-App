using System.Linq.Expressions;

namespace ChatApp.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> expression);



    void AddRange(IEnumerable<TEntity> entities);
    void Add(TEntity entity);


    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}