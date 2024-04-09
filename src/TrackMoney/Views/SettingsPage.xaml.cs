using TrackMoney.ViewModels;

namespace TrackMoney.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        this.AssignViewModel<SettingsVM>();
    }
}