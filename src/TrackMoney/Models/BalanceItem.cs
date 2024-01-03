namespace TrackMoney.Models;

public class BalanceItem : BaseModel
{
    public string OperationCode { get; set; } = Guid.NewGuid().ToString();
    public double Amount { get; set; }
    public bool Sync { get; set; }
}
