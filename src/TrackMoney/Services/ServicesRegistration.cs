namespace TrackMoney.Services;

internal static class ServicesRegistration
{
    internal static MauiAppBuilder AddServices(this MauiAppBuilder builder) 
    {

        builder.Services.
            AddSingleton<INavigationService, NavigationService>();

        return builder;
    }
}
