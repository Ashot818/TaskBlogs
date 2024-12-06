using System.Linq.Expressions;

namespace BlogApi.Repository.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken, params Expression<Func<T, object>>[] includeProperties);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includeProperties);
    Task<T?> FirstOrDefaultWithTrackingAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includeProperties);
    Task<ICollection<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    T Update(T entity);
}
