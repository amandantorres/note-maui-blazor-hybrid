namespace NotesMauiBlazorWasm.Common.Interfaces;

public interface IAlertService
{
    Task<string?> PromptAsync(string message, string title);
    Task AlertAsync(string message, string title = "Alert", string buttonName = "Ok");
    Task<bool> ConfirmAsync(string message, string title = "Confirm", string okButton = "Ok", string cancelButton = "Cancel");
}
