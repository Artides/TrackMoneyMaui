namespace TrackMoney.Models;

internal class Setting: BaseModel
{
    public int Theme { get; set; }
    public string LocalizationCode { get; set; } = "en";
}
