namespace TrackMoney.Models;

public class BalanceItem : BaseModel
{
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();
    public string? OperationType { get; set; }
    public double Amount { get; set; }
    public bool Sync { get; set; }
}
