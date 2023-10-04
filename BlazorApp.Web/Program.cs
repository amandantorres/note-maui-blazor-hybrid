using BlazorApp.Web;
using BlazorApp.Web.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NotesMauiBlazorWasm.Common.Interfaces;
using NotesMauiBlazorWasm.Common.Services;
using NotesMauiBlazorWasm.Common.States;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<GlobalAppState>();

builder.Services.AddTransient<AuthService>();
builder.Services.AddSingleton<IAlertService, AlertService>();
builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddSingleton<IPlatformService, PlatformService>();
builder.Services.AddSingleton<NotesService>();

await builder.Build().RunAsync();
