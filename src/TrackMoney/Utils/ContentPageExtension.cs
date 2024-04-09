using TrackMoney.ViewModels;

namespace TrackMoney.Utils;

internal static class ContentPageExtension

{
    internal static T? AssignViewModel<T>(this ContentPage page) where T : BaseViewModel
    {
        var VM = MauiProgram.GetService<T>() ?? null;

        if (VM != null)
        {
            page.BindingContext = VM;
            page.Appearing += (s, e) => VM.OnAppearing();
            page.Disappearing += (s, e) => VM.OnDisappearing();
        }
        else
            throw new Exception($"Missing View Model '{nameof(T)}' in service provider. Please register it in ViewModelRegistration.cs");

        return VM;
    }

}
