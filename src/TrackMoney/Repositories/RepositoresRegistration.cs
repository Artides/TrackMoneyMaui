using TrackMoney.Models;

namespace TrackMoney.Repositories;

internal static class RepositoresRegistration
{
    internal static MauiAppBuilder AddRepositories(this MauiAppBuilder builder)
    {
        builder.Services
            .AddScoped<IBalanceRepository, BalanceRepository>()
            .AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>()
            .AddScoped<IRepository<Setting>, Repository<Setting>>()
            ;
        return builder;
    }
}
