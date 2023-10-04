namespace BlazorApp.Web.Service;
using Microsoft.JSInterop;
using NotesMauiBlazorWasm.Common.Interfaces;

public class StorageService: IStorageService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly string _storageName = "window.localStorage";

    public StorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string?> GetAsync(string key) =>
        await _jsRuntime.InvokeAsync<string?>($"{_storageName}.getItem", key);
    public async Task SaveAsync(string key, string value) => await _jsRuntime.InvokeVoidAsync($"{_storageName}.setItem",key, value);
}
