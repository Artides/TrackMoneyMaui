namespace TrackMoney.ViewModels;

internal static class ViewModelRegistration
{

    internal static MauiAppBuilder AddViewModels(this MauiAppBuilder builder) {

        builder.Services
            .AddTransient<HomeVM>()
            .AddTransient<EditBalanceVM>()
            .AddTransient<HistoryVM>()
            .AddTransient<SettingsVM>();

        return builder;
    }
}
