using System.Linq.Expressions;

namespace OnlineShop.Infrastructure.PersistenceBase;

public interface IPersisterlayers
{
    T[] GetAll<T>() where T : class;
    Task<T> Get<T>(int id) where T : class;
    void Update<T>(T t) where T : class;
    Task AddAsync<T>(T entity) where T : class;
    Task<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class;
    void Remove(int id);
    Task CommitAsync();
}
