using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TrackMoney.Repositories;
using TrackMoney.Services;
using TrackMoney.ViewModels;
using TrackMoney.Views;

namespace TrackMoney;

public static class MauiProgram
{

    public static MauiApp? App { get; private set; }

    public static IServiceProvider? ServiceProvider => App?.Services.CreateScope().ServiceProvider;

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .AddViewModels()
            .AddServices()
            .AddRepositories()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FA6Brands.otf", "FA6Brands");
                fonts.AddFont("FA6Regular.otf", "FA6Regular");
                fonts.AddFont("FA6Solid.otf", "FA6Solid");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        App = builder.Build();
        
        StartupOperations();

        return App;
    }

    private static void StartupOperations() 
    {
        ServiceProvider?.GetService<INavigationService>()?.RegisterRoutes();
    }

}
