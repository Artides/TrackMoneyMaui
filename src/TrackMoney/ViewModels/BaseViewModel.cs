using CommunityToolkit.Mvvm.ComponentModel;
using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal class BaseViewModel(INavigationService navigationService) : ObservableObject
{
    protected readonly INavigationService _navigationService = navigationService;
}
