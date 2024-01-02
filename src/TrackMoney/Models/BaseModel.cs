using SQLite;

namespace TrackMoney.Models;

public abstract class BaseModel
{
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
