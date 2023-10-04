using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesMauiBlazorWasm.Common.Interfaces
{
    public interface IPlatformService
    {
        bool IsBrowser { get; }

        Task<string?> ChooseFromOptions(string title, params string[] options)
        {
            return null;
        }

        Task CopyToClipboardAsync(string text);
        Task ShareAsync(string text);
    }
}
