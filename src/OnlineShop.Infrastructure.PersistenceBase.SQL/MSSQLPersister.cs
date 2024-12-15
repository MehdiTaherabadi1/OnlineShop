using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.PersistenceBase.SQL.DbContext;
using System.Linq.Expressions;

namespace OnlineShop.Infrastructure.PersistenceBase.SQL;

public class MSSQLPersister : IPersisterlayers
{
    private ApplicationDbContext _Context;
    public MSSQLPersister(ApplicationDbContext context)
    {
        _Context = context;
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await _Context.Set<T>().AddAsync(entity);
    }

    public async Task CommitAsync()
    {
        await _Context.SaveChangesAsync();
    }

    public async Task<T> Get<T>(int id) where T : class
    {
        return await _Context.Set<T>().FindAsync(id);
    }

    public async Task<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        return await _Context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public T[] GetAll<T>() where T : class
    {
        return _Context.Set<T>().ToArray();
    }

    public void Remove(int id)
    {
        _Context.Remove(id);
    }

    public void Update<T>(T entity) where T : class
    {
        _Context.Set<T>().Update(entity);
    }
}


