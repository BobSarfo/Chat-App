using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChatApp.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ChatAppDbContext _context;

    protected BaseRepository(ChatAppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }


    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().Where(expression).ToListAsync();
    }

    public async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
    }

    public void Add(TEntity entity)
    {
      _context.Set<TEntity>().Add(entity);
    }
    public void AddRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRangeAsync(entities);
    }


    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }


}