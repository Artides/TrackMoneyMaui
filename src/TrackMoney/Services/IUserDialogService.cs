namespace TrackMoney.Services;

internal interface IUserDialogService
{
    Task ShowAlertAsync(string message);
    Task ShowAlertAsync(string message, string okButton);
    Task ShowAlertAsync(string title, string message, string okButton);
}
