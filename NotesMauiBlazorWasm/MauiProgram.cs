using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using NotesMauiBlazorWasm.Common.Interfaces;
using NotesMauiBlazorWasm.Common.Services;
using NotesMauiBlazorWasm.Common.States;
using NotesMauiBlazorWasm.Services;

namespace NotesMauiBlazorWasm
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .UseMauiCommunityToolkit();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<GlobalAppState>();
            builder.Services.AddTransient<AuthService>();
            builder.Services.AddSingleton<IAlertService, AlertService>();
            builder.Services.AddSingleton<IStorageService, StorageService>();
            builder.Services.AddSingleton<IPlatformService, PlatformService>();
            builder.Services.AddSingleton<NotesService>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}