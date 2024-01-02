namespace TrackMoney.Services;

internal interface INavigationService
{
    void RegisterRoutes();

    void NavigateToPage(string pageRoute, params (string, object)[] parameters);

    void NavigateBack();

}
