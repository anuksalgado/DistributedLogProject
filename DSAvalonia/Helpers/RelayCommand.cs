using System;
using System.Windows.Input;

namespace DSAvalonia.Helpers
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? (() => true);  // Default to always executable
        }

        public bool CanExecute(object parameter) => _canExecute();

        public void Execute(object parameter) => _execute();

        // Remove the add/remove accessor for CanExecuteChanged, since Avalonia does not require it.
        public event EventHandler CanExecuteChanged;

        // Method to manually trigger CanExecuteChanged
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
