using TrackMoney.Models;

namespace TrackMoney.Repositories;

internal static class RepositoresRegistration
{
    internal static MauiAppBuilder AddRepositories(this MauiAppBuilder builder)
    {
        builder.Services
            .AddScoped<IRepository<BalanceItem>, Repository<BalanceItem>>()
            .AddScoped<IRepository<Setting>, Repository<Setting>>()
            ;
        return builder;
    }
}
