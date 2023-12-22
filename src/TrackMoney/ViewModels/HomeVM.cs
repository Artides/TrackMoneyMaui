using CommunityToolkit.Mvvm.Input;
using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal partial class HomeVM(INavigationService navigationService) : BaseViewModel(navigationService)
{
    [RelayCommand]
    void OpenSettings() 
    {
        _navigationService.NavigateToPage(nameof(SettingsVM));
    }

}
