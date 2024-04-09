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

    public SQLiteAsyncConnection? GetConnection()
    {
        _database ??= new SQLiteAsyncConnection(dbPath, Flags);
        return _database;
    }

    public Task AddOrUpdateTable<TEntity>() where TEntity : BaseModel => _database?.CreateTableAsync(typeof(TEntity)) ?? throw new Exception("Database connection is null.");
}
