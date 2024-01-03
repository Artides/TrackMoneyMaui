using TrackMoney.Models;

namespace TrackMoney.Services;

internal interface ISettingService
{
    void Init();
    Task<Setting> GetSetting();
    Task<Setting> SaveSetting(Setting setting);

    AppTheme GetTheme();
    Task SetTheme(AppTheme theme);
}
