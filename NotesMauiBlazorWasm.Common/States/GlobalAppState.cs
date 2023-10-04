using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesMauiBlazorWasm.Common.States
{
    public class GlobalAppState : INotifyPropertyChanged
    {
        private bool _isInitializing = true;

        public bool IsInitializing
        {
            get => _isInitializing;
            set
            {
                _isInitializing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsInitializing)));
            }
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get { return _errorMessage; }
            set { 
                _errorMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsInitializing)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
