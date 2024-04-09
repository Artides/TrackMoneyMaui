using SQLite;
using System.Linq.Expressions;
using TrackMoney.Models;
using TrackMoney.Services;

namespace TrackMoney.Repositories;

internal class Repository<T> : IRepository<T> where T : BaseModel, new()
{
    private readonly SQLiteAsyncConnection _connection;
    public Repository(ISqliteService sqliteService, bool registerSqliteTable = true)
    {
        _connection = sqliteService.GetConnection() ?? throw new Exception("The sqlite connection is null.");
        if (registerSqliteTable)
        {
            sqliteService.AddOrUpdateTable<T>();
        }
    }

    public virtual Task<List<T>> GetAsync()
    {
        return _connection.Table<T>().ToListAsync();
    }

    public virtual Task<T> GetAsync(int id)
    {
        return _connection.FindAsync<T>(id);
    }

    public virtual Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return _connection.Table<T>().Where(predicate).ToListAsync();
    }

    public virtual async Task<T> InsertOrUpdateAsync(T entity)
    {
        if (entity.Id >= 0 && await GetAsync(entity.Id) != null)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            await _connection.UpdateAsync(entity);
            return entity;
        }
        else
        {
            entity.Id = 0;
            await _connection.InsertAsync(entity);
            return entity;
        }
    }


    public async virtual Task<bool> DeleteAsync(T entity)
    {
        var result = await _connection.DeleteAsync(entity);
        return result > 0;
    }


    public virtual Task TruncateAsync()
    {
        return _connection.DeleteAllAsync<T>();
    }
}
