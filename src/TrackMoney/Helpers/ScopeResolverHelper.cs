using TrackMoney.ViewModels;

namespace TrackMoney.Helpers;

internal static class ScopeResolverHelper

{
    internal static T? AssignViewModel<T>(this ContentPage page) where T : BaseViewModel
    {
        var VM = MauiProgram.ServiceProvider?
            .GetService<T>() ?? null;

        if (VM != null) page.BindingContext = VM;

        return VM;


    }

}
