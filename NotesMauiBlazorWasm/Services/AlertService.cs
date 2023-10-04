using NotesMauiBlazorWasm.Common.Interfaces;

namespace NotesMauiBlazorWasm.Services;

public class AlertService : IAlertService
{
    private readonly Page _page;

    public AlertService()
    {
        _page = App.Current.MainPage;
    }
    public async Task AlertAsync(string message, string title = "Alert", string buttonName = "Ok")
    {
        await _page.DisplayAlert(title, message, buttonName);
    }

    public async Task<bool> ConfirmAsync(string message, string title = "Confirm", string okButton = "Ok", string cancelButton = "Cancel")
    {
        return await _page.DisplayAlert(message, title, okButton, cancelButton);
    }

    public Task<string> PromptAsync(string message, string title)
    {
        return _page.DisplayPromptAsync(title, message, "Ok");
    }
}
