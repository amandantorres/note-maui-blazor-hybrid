using Microsoft.JSInterop;
using NotesMauiBlazorWasm.Common.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorApp.Web.Service;

public class AlertService : IAlertService
{
    private readonly IJSRuntime _jsRuntime;

    public AlertService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    public async Task AlertAsync(string message, string title = "Alert", string buttonName = "Ok")
    {
        await _jsRuntime.InvokeVoidAsync("window.alert", $"{title}\n{message}");
    }

    public async Task<bool> ConfirmAsync(string message, string title = "Confirm", string okButton = "Ok", string cancelButton = "Cancel")
    {
        return await _jsRuntime.InvokeAsync<bool>("window.confirm", $"{title}\n{message}");
    }

    public async Task<string> PromptAsync(string message, string title)
    {
        return await _jsRuntime.InvokeAsync<string?>("window.prompt", $"{title}\n{message}");
    }
}