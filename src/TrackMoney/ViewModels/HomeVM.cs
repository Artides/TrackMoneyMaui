using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal partial class HomeVM(INavigationService navigationService) : BaseViewModel(navigationService)
{
    [ObservableProperty]
    GridLength proceedPercentage = new(0.5, GridUnitType.Star);

    [ObservableProperty]
    GridLength expensePercentage = new(0.5, GridUnitType.Star);

    public override Task OnAppearing()
    {
        var percentage = 0.2;
        ProceedPercentage = new GridLength(percentage, GridUnitType.Star);
        ExpensePercentage = new GridLength(1 - percentage, GridUnitType.Star);

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
