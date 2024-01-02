using SQLite;

namespace TrackMoney.Services;

internal interface ISqliteService
{
    void InitDatabase(params Type[] tables);
    SQLiteAsyncConnection? GetConnection();
}
