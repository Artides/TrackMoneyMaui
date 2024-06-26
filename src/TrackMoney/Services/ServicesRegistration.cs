﻿namespace TrackMoney.Services;

internal static class ServicesRegistration
{
    internal static MauiAppBuilder AddServices(this MauiAppBuilder builder) 
    {

        builder.Services
            .AddSingleton<INavigationService, NavigationService>()
            .AddSingleton<ISqliteService, SqliteService>()
            .AddSingleton<ISettingService, SettingService>()
            .AddSingleton<IBalanceService, BalanceService>()
            .AddSingleton<IQueueOperationsService, QueueOperationsService>()
            ;

        return builder;
    }
}
