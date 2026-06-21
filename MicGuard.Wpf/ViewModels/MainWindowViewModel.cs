using MicGuard.Wpf.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MicGuard.Wpf.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand ToggleEnabledCommand { get; }

        private bool isEnabled = false;

        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                if (isEnabled == value)
                    return;

                isEnabled = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(StatusText));
                OnPropertyChanged(nameof(StatusColor));
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        public string StatusText => IsEnabled ? "Active" : "Inactive";
        public string ButtonText => IsEnabled ? "Disable" : "Enable";
        public string StatusColor => IsEnabled ? "#50C878" : "#000000";

        public MainWindowViewModel()
        {
            ToggleEnabledCommand = new RelayCommand(ToggleEnabled);
        }

        private void ToggleEnabled()
        {
            IsEnabled = !IsEnabled;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
