using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.Threading.Tasks;
using System.Threading;

namespace WPF.MVVMDemo
{
    public class MainViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ModelSimulator engine;
        public MainViewModel()
        {
            dataStringFromEngine = string.Empty;
            calculatingStatus = string.Empty;
            isEngineFree = true;
            engine = new ModelSimulator();
            calculateCommand = new DelegateCommand(this.executeCalculateCommand, this.canExecuteCalculateCommand);
            calculateCommandWithParameter = new DelegateCommand<string>(this.executeCalculateCommandWithParameter, this.canExecuteCalculateCommandWithParameter);
            winloadedCommand = new DelegateCommand(this.executeWinloadedCommand, this.canWinloadedCommand);
            cancelCalculateCommand = new DelegateCommand(this.executeCancelCalculateCommand, this.canExecuteCancelCalculateCommand);
        }
        private string dataStringFromEngine;
        public string DataStringFromEngine
        {
            get { return dataStringFromEngine; }
            set
            {
                if (dataStringFromEngine != value)
                {
                    dataStringFromEngine = value;
                    OnPropertyChagned("DataStringFromEngine");
                }
            }
        }
        private string calculatingStatus;
        public string CalculatingStatus
        {
            get { return calculatingStatus; }
            set
            {
                if (calculatingStatus != value)
                {
                    calculatingStatus = value;
                    OnPropertyChagned("CalculatingStatus");
                }
            }
        }
        private bool isEngineFree;
        public bool IsEngineFree
        {
            get { return isEngineFree; }
            set
            {
                if (isEngineFree != value)
                {
                    isEngineFree = value;
                    OnPropertyChagned("IsEngineFree");
                    ((DelegateCommand)calculateCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand<string>)calculateCommandWithParameter).RaiseCanExecuteChanged();
                    ((DelegateCommand)cancelCalculateCommand).RaiseCanExecuteChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }
        #region CalculateCommand
        private ICommand calculateCommand;
        public ICommand CalculateCommand
        {
            get { return calculateCommand; }
            set
            {
                if (calculateCommand != value)
                {
                    calculateCommand = value;
                    OnPropertyChagned("CalculateCommand");
                }
            }
        }
        private void executeCalculateCommand()
        {
            IsEngineFree = false;
            CalculatingStatus = "Running!";
            // create parallel task ,async

            Task<string> engineTask = Task.Factory.StartNew<string>(() => engine.SimulateLongTimeWork(5));
            //UI callback               
            engineTask.ContinueWith(task =>
            {

                this.DataStringFromEngine = task.Result;
                IsEngineFree = true;
                CalculatingStatus = "Complete!";
            });
        }
        private bool canExecuteCalculateCommand()
        {
            return isEngineFree;
        }
        #endregion
        #region CalculateCommandWithParameter
        private ICommand calculateCommandWithParameter;
        public ICommand CalculateCommandWithParameter
        {
            get { return calculateCommandWithParameter; }
            set
            {
                if (calculateCommandWithParameter != value)
                {
                    calculateCommandWithParameter = value;
                    OnPropertyChagned("CalculateCommandWithParameter");
                }
            }
        }
        private void executeCalculateCommandWithParameter(string para)
        {
            IsEngineFree = false;
            CalculatingStatus = "Running!";
            // create parallel task ,async
            Task<string> engineTask = Task.Factory.StartNew<string>(() => engine.SimulateLongTimeWorkWithParameter(para, 5));
            //UI callback            
            engineTask.ContinueWith(task =>
            {

                this.DataStringFromEngine = task.Result;
                IsEngineFree = true;
                CalculatingStatus = "Complete!";
            });

        }
        private bool canExecuteCalculateCommandWithParameter(string para)
        {
            return isEngineFree;
        }
        #endregion
        #region
        private ICommand winloadedCommand;
        public ICommand WinloadedCommand
        {
            get { return winloadedCommand; }
            set
            {
                if (winloadedCommand != value)
                {
                    winloadedCommand = value;
                    OnPropertyChagned("WinloadedCommand");
                }
            }
        }
        private void executeWinloadedCommand()
        {
            CalculatingStatus = "The WinloadedCommand has been called!";
        }
        private bool canWinloadedCommand()
        {
            return true;
        }
        #endregion

        private ICommand cancelCalculateCommand;
        public ICommand CancelCalculateCommand
        {
            get { return cancelCalculateCommand; }
            set
            {
                if (cancelCalculateCommand != value)
                {
                    cancelCalculateCommand = value;
                    OnPropertyChagned("CancelCalculateCommand");
                }
            }
        }
        private void executeCancelCalculateCommand()
        {
        }
        private bool canExecuteCancelCalculateCommand()
        {
            return !isEngineFree;
        }
        private void OnPropertyChagned(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
