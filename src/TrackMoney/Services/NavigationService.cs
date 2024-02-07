using TrackMoney.ViewModels;
using TrackMoney.Views;

namespace TrackMoney.Services
{
    internal class NavigationService : INavigationService
    {
        public void NavigateBack()
        {
            Shell.Current.GoToAsync("..");
        }

        public void NavigateToPage(string pageRoute, params (string,object)[] parameters)
        {
            var dictionary = new Dictionary<string, object>();

            if (parameters != null && parameters.Any())
                foreach (var p in parameters) dictionary.TryAdd(p.Item1, p.Item2);

            Shell.Current.GoToAsync(pageRoute, dictionary);
        }

        public void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(HomeVM), typeof(HomePage));
            Routing.RegisterRoute(nameof(EditBalanceVM), typeof(EditBalancePage));
            Routing.RegisterRoute(nameof(HistoryVM), typeof(HistoryPage));
            Routing.RegisterRoute(nameof(SettingsVM), typeof(SettingsPage));
        }
    }
}
