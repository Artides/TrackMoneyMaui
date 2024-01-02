using SQLite;
using System.Linq.Expressions;
using TrackMoney.Models;
using TrackMoney.Services;

namespace TrackMoney.Repositories;

internal class Repository<T>(ISqliteService sqliteService) : IRepository<T> where T : BaseModel, new()
{
    private readonly SQLiteAsyncConnection _connection = sqliteService.GetConnection() ?? throw new Exception("The sqlite connection is null.");

    public virtual Task<List<T>> Get()
    {
        return _connection.Table<T>().ToListAsync();
    }

    public virtual Task<T> Get(int id)
    {
        return _connection.FindAsync<T>(id);
    }

    public virtual Task<List<T>> Get(Expression<Func<T, bool>> predicate)
    {
        return _connection.Table<T>().Where(predicate).ToListAsync();
    }

    public virtual async Task<T> InsertOrUpdate(T entity)
    {
        if (entity.Id >= 0 && await Get(entity.Id) != null)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            await _connection.UpdateAsync(entity);
            return entity;
        }
        else
        {
            await _connection.InsertAsync(entity);
            return entity;
        }
    }


    public virtual Task Delete(T entity)
    {
        return _connection.DeleteAsync(entity);
    }


    public virtual Task Truncate()
    {
        return _connection.DeleteAllAsync<T>();
    }
}
