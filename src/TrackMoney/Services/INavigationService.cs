using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMoney.Services
{
    internal interface INavigationService
    {
        void RegisterRoutes();

        void NavigateToPage(string pageRoute, IDictionary<string, object>? parameters = null);

        void NavigateBack();

    }
}
