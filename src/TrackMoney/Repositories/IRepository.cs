using System.Linq.Expressions;
using TrackMoney.Models;

namespace TrackMoney.Repositories;

interface IRepository<T> where T : BaseModel, new()
{
    Task<List<T>> Get();
    Task<T> Get(int id);
    Task<List<T>> Get(Expression<Func<T, bool>> predicate);
    Task<T> InsertOrUpdate(T entity);
    Task Delete(T entity);
    Task Truncate();
}
