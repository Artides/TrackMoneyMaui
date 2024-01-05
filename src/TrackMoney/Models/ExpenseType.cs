using SQLite;

namespace TrackMoney.Models;

internal class ExpenseType : BaseModel
{
    public string? Code { get; set; }
    public string? Description { get; set; }

    [Ignore]
    public string? LocalizedDescription => Description?.Translate();
}
