using SQLite;
using TrackMoney.Models;

namespace TrackMoney.Services;

internal interface ISqliteService
{
    Task AddOrUpdateTable<TEntity>() where TEntity : BaseModel;
    SQLiteAsyncConnection? GetConnection();
}
