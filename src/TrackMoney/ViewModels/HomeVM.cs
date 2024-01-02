using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal partial class HomeVM(INavigationService navigationService) : BaseViewModel(navigationService)
{
    [ObservableProperty]
    GridLength proceedPercentage = GridLength.Star;

    public override Task OnAppearing()
    {
        ProceedPercentage = new GridLength(1.5, GridUnitType.Star);

        return base.OnAppearing();
    }

    [RelayCommand]
    void OpenSettings()
    {
        _navigationService.NavigateToPage(nameof(SettingsVM));
    }

    [RelayCommand]
    void AddExpense()
    {
        _navigationService.NavigateToPage(nameof(EditBalanceVM), (nameof(EditBalanceVM.BalanceType), EditType.Expense));
    }
    [RelayCommand]
    void AddProceed()
    {
        _navigationService.NavigateToPage(nameof(EditBalanceVM), (nameof(EditBalanceVM.BalanceType), EditType.Proceed));
    }

}
