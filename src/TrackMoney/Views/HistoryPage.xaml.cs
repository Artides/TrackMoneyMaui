using TrackMoney.ViewModels;

namespace TrackMoney.Views;

public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
        this.AssignViewModel<HistoryVM>();
    }
}