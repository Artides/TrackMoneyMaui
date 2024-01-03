using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TrackMoney.Models;
using TrackMoney.Repositories;
using TrackMoney.Services;
using TrackMoney.ViewModels;

namespace TrackMoney;

public static class MauiProgram
{

    static MauiApp? App;

    public static T? GetService<T>()
    {
        if (App == null) throw new ArgumentNullException(nameof(MauiApp));
        return App.Services.CreateScope().ServiceProvider.GetService<T>();
    }

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
        return App;
    }

}
