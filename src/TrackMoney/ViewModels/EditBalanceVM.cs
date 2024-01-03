using CommunityToolkit.Mvvm.ComponentModel;
using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal enum EditType : int
{
    Expense = 0,
    Proceed = 1,
}

internal partial class EditBalanceVM(INavigationService navigationService) : BaseViewModel(navigationService)
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private double? quantity;

    public EditType? BalanceType { get; private set; }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.NullOrEmpty()) return;

        if (query.TryGetValue(nameof(BalanceType), out object? value)) BalanceType = value as EditType?;
    }

    public override Task OnAppearing()
    {
        Title = BalanceType switch
        {
            EditType.Expense => AppRes.AddExpenses,
            EditType.Proceed => AppRes.AddProceeds,
            _ => throw new Exception("BalanceType is not valid"),
        };
        return base.OnAppearing();
    }


}
