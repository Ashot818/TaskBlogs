using BlogApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogApi.Repository.Implementations;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DbContext _dbContext;

    protected BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        return result.Entity;
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _dbContext.Set<T>().AsNoTracking();

        foreach (var property in includeProperties)
            query = query.Include(property);

        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<T?> FirstOrDefaultWithTrackingAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _dbContext.Set<T>().AsQueryable();

        foreach (var property in includeProperties)
            query = query.Include(property);

        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken, params Expression<Func<T, object>>[] includeProperties)
    {

        var query = _dbContext.Set<T>().AsQueryable();

        foreach (var property in includeProperties)
            query = query.Include(property);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<ICollection<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }

    public T Update(T entity)
    {
        var result = _dbContext.Set<T>().Update(entity);
        return result.Entity;
    }
}
