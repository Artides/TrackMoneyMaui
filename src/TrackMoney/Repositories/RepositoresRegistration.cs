using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMoney.Models;

namespace TrackMoney.Repositories
{
    internal static class RepositoresRegistration
    {
        internal static MauiAppBuilder AddRepositories(this MauiAppBuilder builder)
        {
            builder.Services
                .AddScoped<IRepository<BalanceItem>, Repository<BalanceItem>>();
            return builder;
        }
    }
}
