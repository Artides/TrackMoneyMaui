using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal partial class SettingsVM(INavigationService navigationService, ISettingService settingService) : BaseViewModel(navigationService)
{

    [ObservableProperty]
    bool isOsMode;
    [ObservableProperty]
    bool isLightMode;
    [ObservableProperty]
    bool isDarkMode;

    private readonly ISettingService _settingService = settingService;

    private AppTheme currentTheme;

    public async override Task OnAppearing()
    {
        UpdateThemeMode();
        await base.OnAppearing();
    }

    private void UpdateThemeMode()
    {
        currentTheme = _settingService.GetTheme();
        IsOsMode = currentTheme == AppTheme.Unspecified;
        IsLightMode = currentTheme == AppTheme.Light;
        IsDarkMode = currentTheme == AppTheme.Dark;
    }

    [RelayCommand]
    async void SetTheme(AppTheme theme)
    {
        await _settingService.SetTheme(theme);
        UpdateThemeMode();
    }

}
