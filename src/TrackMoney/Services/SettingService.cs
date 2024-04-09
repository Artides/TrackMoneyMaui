using TrackMoney.Models;
using TrackMoney.Repositories;

namespace TrackMoney.Services;

internal class SettingService(IRepository<Setting> settingRepo) : ISettingService
{
    private readonly IRepository<Setting> settingRepo = settingRepo;
    private Setting? setting;

    public async Task<Setting> GetSetting()
    {
        if (setting != null) return setting;
        setting = await settingRepo.GetAsync(1);
        setting ??= new Setting();
        return setting;
    }

    public AppTheme GetTheme() => Application.Current?.UserAppTheme ?? AppTheme.Unspecified;

    public async void Init()
    {
        setting ??= await GetSetting();
        await SetTheme((AppTheme)setting.Theme);
    }

    public Task<Setting> SaveSetting(Setting setting)
    {
        if (setting.Id != 0) setting.Id = 1;
        return settingRepo.InsertOrUpdateAsync(setting);
    }

    public async Task SetTheme(AppTheme theme)
    {
        Application.Current.UserAppTheme = theme;
        setting ??= await GetSetting();
        if (setting.Theme != (int)theme)
        {
            setting.Theme = (int)theme;
            await SaveSetting(setting);
        }
    }
}
