using Microsoft.JSInterop;
using NotesMauiBlazorWasm.Common.Interfaces;

namespace BlazorApp.Web.Service
{
    public class PlatformService : IPlatformService
    {
        private readonly IJSRuntime _jsRuntime;

        public PlatformService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public bool IsBrowser => true;

        public async Task CopyToClipboardAsync(string text)
        {
            await _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }

        public Task ShareAsync(string text)
        {
            throw new NotImplementedException();
        }
    }
}
