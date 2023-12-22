using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMoney.ViewModels;
using TrackMoney.Views;

namespace TrackMoney.Services
{
    internal class NavigationService : INavigationService
    {
        public void NavigateBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateToPage(string pageRoute, IDictionary<string,object>? parameters = null)
        {
            Shell.Current.GoToAsync(pageRoute, parameters ?? new Dictionary<string, object>());
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
