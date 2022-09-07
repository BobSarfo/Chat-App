using ChatApp.Data.Contexts;
using ChatApp.Domain.Repositories;
using System.Linq.Expressions;

namespace ChatApp.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ChatAppDbContext _context;

    protected BaseRepository(ChatAppDbContext context)
    {
        _context = context;
    }


    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
    {
        return _context.Set<TEntity>().Where(expression);
    }

    public async Task<TEntity> SaveAsync(TEntity entity)
    {
        var entity1 = _context.Set<TEntity>().Add(entity).Entity;
        await _context.SaveChangesAsync();
        return entity1;
    }

    public ValueTask<TEntity?> GetByIdAsync(Guid id)
    {
        return _context.Set<TEntity>().FindAsync(id);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}