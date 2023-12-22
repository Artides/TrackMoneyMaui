using TrackMoney.ViewModels;
namespace TrackMoney.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        this.AssignViewModel<HomeVM>();
    }
}