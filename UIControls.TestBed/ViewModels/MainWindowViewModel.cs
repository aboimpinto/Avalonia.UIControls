using System;
using System.Collections;
using System.ComponentModel;
using ReactiveUI;

namespace UIControls.TestBed.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private string greeting = string.Empty;

        private string _greetingsError = string.Empty;

        public string Greeting 
        { 
            get => greeting; 
            set => this.RaiseAndSetIfChanged( ref greeting, value); 
        }

        public bool HasErrors => throw new NotImplementedException();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public MainWindowViewModel()
        {
            this.WhenAnyValue(x => x.Greeting)
                .Subscribe(_ => this.UpdateErrors());
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            switch(propertyName)
            {
                case nameof(this.Greeting):
                    return new[] { this._greetingsError };
                default:
                    return null;
            }
        }

        private void UpdateErrors()
        {
            if (string.IsNullOrEmpty(this.Greeting))
            {
                this._greetingsError = "TextBox cannot be empty!";
                this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(this.Greeting)));
            }
            else
            {
                this._greetingsError = null;
                this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(this.Greeting)));
            }
        }
    }
}
