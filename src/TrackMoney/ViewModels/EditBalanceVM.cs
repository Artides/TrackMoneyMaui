using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrackMoney.Models;
using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal enum EditType : int
{
    Expense = 0,
    Proceed = 1,
}

internal partial class EditBalanceVM(
    INavigationService navigationService,
    IBalanceService balanceService) : BaseViewModel(navigationService)
{
    private readonly IBalanceService balanceService = balanceService;

    [ObservableProperty]
    private string? title;

    [ObservableProperty]
    private double? quantity;

    [ObservableProperty]
    private List<ExpenseType>? expenseTypes;

    [ObservableProperty]
    private ExpenseType? selectedExpenseType;

    [ObservableProperty]
    private bool expenseTypesIsVisible;

    public EditType? BalanceType { get; private set; }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.NullOrEmpty()) return;

        if (query.TryGetValue(nameof(BalanceType), out object? value)) BalanceType = value as EditType?;
    }

    public async override Task OnAppearing()
    {
        switch (BalanceType)
        {
            case EditType.Expense:
                Title = AppRes.AddExpenses;
                ExpenseTypes = await balanceService.GetExpenseTypesAsync();
                ExpenseTypesIsVisible = true;
                break;
            case EditType.Proceed:
                Title = AppRes.AddProceeds;
                ExpenseTypesIsVisible = false;
                var proceedType = await balanceService.GetProceedTypeAsync();
                ExpenseTypes = [proceedType];
                SelectedExpenseType = proceedType;
                break;
            case null:
            default:
                throw new Exception("BalanceType is not valid");
        }

        await base.OnAppearing();
    }

    [RelayCommand]
    void AddBalance()
    {
        if (Quantity == null || Quantity == 0) return;

        if (SelectedExpenseType == null) return;

        balanceService.AddToBalanceAsync(SelectedExpenseType, Quantity.Value);

    }

}
