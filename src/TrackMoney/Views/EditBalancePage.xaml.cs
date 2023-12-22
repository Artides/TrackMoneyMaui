using TrackMoney.ViewModels;

namespace TrackMoney.Views;

public partial class EditBalancePage : ContentPage
{
	public EditBalancePage()
	{
		InitializeComponent();
        this.AssignViewModel<EditBalanceVM>();
    }
}