using NotesMauiBlazorWasm.Common.Interfaces;

namespace NotesMauiBlazorWasm.Common.Services;

public class AuthService
{
    private readonly IAlertService _alertService;
    private readonly IStorageService _storageService;

    public AuthService(IAlertService alertService, IStorageService storageService)
    {
        _alertService = alertService;
        _storageService = storageService;
    }
    public async Task<string?> GetUsername()
    {
        var name = await _storageService.GetAsync(AppConstants.StorageKeys.Username);
        if (string.IsNullOrWhiteSpace(name))
        {
            int maxRetry = 3;
            do
            {
                name = await _alertService.PromptAsync("Please enter your name", "Welcome");
            } 
            while (string.IsNullOrWhiteSpace(name) && (--maxRetry) > 0);
            if (string.IsNullOrWhiteSpace(name))
            {
                await _alertService.AlertAsync("Your name is required to continue with the app", "error", "ok");
                return null;
            }
            await _storageService.SaveAsync(AppConstants.StorageKeys.Username, name);
        }

        return name;
    }
}