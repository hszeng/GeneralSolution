using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace TimeOutTask
{
    public class DelegateCommand : ICommand
    {
        private readonly Action commandHandler;
        private readonly Func<bool> canExecuteHandler;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action commandHandler, Func<bool> canExecuteHandler = null)
        {
            this.commandHandler = commandHandler;
            this.canExecuteHandler = canExecuteHandler;
        }

        public void Execute(object parameter)
        {
            commandHandler();
        }

        public bool CanExecute(object parameter)
        {
            return
                canExecuteHandler == null ||
                canExecuteHandler();
        }

        public void RaiseCanExecuteChanged()
        {
            if (!Application.Current.Dispatcher.CheckAccess())
            {
                Application.Current.Dispatcher.BeginInvoke((Action)RaiseCanExecuteChanged);
                return;
            }

            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> commandHandler;
        private readonly Func<T, bool> canExecuteHandler;

        public DelegateCommand(Action<T> commandHandler, Func<T, bool> canExecuteHandler = null)
        {
            this.commandHandler = commandHandler;
            this.canExecuteHandler = canExecuteHandler;
        }

        public void Execute(object parameter)
        {
            commandHandler((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return
                canExecuteHandler == null ||
                canExecuteHandler((T)parameter);
        }

        #pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
        #pragma warning restore 0067
    }
}
