using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal partial class SettingsVM(INavigationService navigationService) : BaseViewModel(navigationService)
{

    [ObservableProperty]
    bool isOsMode;
    [ObservableProperty]
    bool isLightMode;
    [ObservableProperty]
    bool isDarkMode;


    public override Task OnAppearing()
    {
        UpdateThemeMode();
        return base.OnAppearing();
    }

    private void UpdateThemeMode()
    {
        IsOsMode = Application.Current.UserAppTheme == AppTheme.Unspecified;
        IsLightMode = Application.Current.UserAppTheme == AppTheme.Light;
        IsDarkMode = Application.Current.UserAppTheme == AppTheme.Dark;
    }

    [RelayCommand]
    void SetTheme(AppTheme theme)
    {
        Application.Current.UserAppTheme = theme;
        UpdateThemeMode();
    }

    [RelayCommand]
    void GoBack()
    {
        _navigationService.NavigateBack();
    }

}
