using CommunityToolkit.Mvvm.ComponentModel;
using TrackMoney.Services;

namespace TrackMoney.ViewModels;

internal class BaseViewModel(INavigationService navigationService) : ObservableObject, IQueryAttributable
{
    protected readonly INavigationService _navigationService = navigationService;

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query){ }
    public virtual Task OnAppearing() => Task.CompletedTask;
    public virtual Task OnDisappearing() => Task.CompletedTask;

}
