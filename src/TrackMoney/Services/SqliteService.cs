using SQLite;
using TrackMoney.Models;

namespace TrackMoney.Services;

internal class SqliteService : ISqliteService
{
    private string dbPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TrackMoney.db");

    private SQLiteAsyncConnection? _database;

    private const SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLiteOpenFlags.SharedCache;


    public async void InitDatabase(params Type[] tables)
    {
        _database = new SQLiteAsyncConnection(dbPath, Flags);

        if (tables.Empty()) return;

        foreach (var table in tables)
        {
            if (table == null || table.BaseType != typeof(BaseModel)) throw new Exception("The type does not derive from BaseModel class");
            await _database.CreateTableAsync(table);
        }
    }

    public SQLiteAsyncConnection? GetConnection() => _database;

}
