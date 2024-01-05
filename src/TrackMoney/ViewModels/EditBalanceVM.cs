using CommunityToolkit.Mvvm.ComponentModel;
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

    public EditType? BalanceType { get; private set; }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.NullOrEmpty()) return;

        if (query.TryGetValue(nameof(BalanceType), out object? value)) BalanceType = value as EditType?;
    }

    public async override Task OnAppearing()
    {
        Title = BalanceType switch
        {
            EditType.Expense => AppRes.AddExpenses,
            EditType.Proceed => AppRes.AddProceeds,
            _ => throw new Exception("BalanceType is not valid"),
        };

        ExpenseTypes = await balanceService.GetExpenseTypesAsync();
        await base.OnAppearing();
    }


}
