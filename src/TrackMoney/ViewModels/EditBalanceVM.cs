using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal enum EditType : int
{
    Expense = 0,
    Proceed = 1,
}

internal partial class EditBalanceVM(INavigationService navigationService) : BaseViewModel(navigationService)
{

    public EditType? BalanceType { get; private set; }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.NullOrEmpty()) return;

        if (query.TryGetValue(nameof(BalanceType), out object? value)) BalanceType = value as EditType?;
    }

    public override Task OnAppearing()
    {
        Console.WriteLine(BalanceType.ToString());
        return base.OnAppearing();
    }


}
