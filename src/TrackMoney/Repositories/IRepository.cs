using System.Linq.Expressions;
using TrackMoney.Models;

namespace TrackMoney.Repositories;

interface IRepository<T> where T : BaseModel, new()
{
    Task<List<T>> GetAsync();
    Task<T> GetAsync(int id);
    Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> InsertOrUpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task TruncateAsync();
}
