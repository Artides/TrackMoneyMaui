using TrackMoney.Repositories;
using TrackMoney.Services;

namespace TrackMoney;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        InitializeServices();
        MainPage = new AppShell();
    }

    private static void InitializeServices()
    {
        MauiProgram.GetService<INavigationService>()?.RegisterRoutes();
        MauiProgram.GetService<ISettingService>()?.Init();
        MauiProgram.GetService<IExpenseTypeRepository>()?.InitDefaultsAsync();
    }
}
