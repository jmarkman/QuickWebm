using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuickWebm.Commands
{
    public class AsyncCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private bool isExecuting;
        private readonly Func<Task> execute;
        private readonly Func<bool> canExecute;

        public AsyncCommand(Func<Task> execute, Func<bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute()
        {
            return !isExecuting && (canExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync()
        {
            if (canExecute())
            {
                try
                {
                    isExecuting = true;
                    await execute();
                }
                finally
                {
                    isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region ICommand Implementation
        bool ICommand.CanExecute(object? parameter)
        {
            return CanExecute();
        }

        async void ICommand.Execute(object? parameter)
        {
            await ExecuteAsync();
        }
        #endregion
    }
}
