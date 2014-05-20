using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;

namespace TimeOutTask
{
    public class ViewModel : INotifyPropertyChanged
    {
        Model engineSimulator;
        private SynchronizationContext synchronizationContext;
        public ViewModel()
        {
            engineSimulator = new Model();
            synchronizationContext = System.Threading.SynchronizationContext.Current;
            worker1StatusCollection = new ObservableCollection<string>();
            Worker1Command = new DelegateCommand(Worker1, () => !IsWorker1Busy);

            Worker2StatusCollection = new ObservableCollection<string>();
            Worker2Command = new DelegateCommand(Worker2, () => !IsWorker2Busy);

            Worker3StatusCollection = new ObservableCollection<string>();
            Worker3Command = new DelegateCommand(Worker3, () => !IsWorker3Busy);
        }

        #region Worker1
        private ObservableCollection<string> worker1StatusCollection;
        public ObservableCollection<string> Worker1StatusCollection
        {
            get { return worker1StatusCollection; }
            set { PropertyChanged.ChangeAndNotify(ref worker1StatusCollection, value, () => Worker1StatusCollection); }
        }
        public void Worker1()
        {
            Worker1StatusCollection.Add(string.Format("Start Worker1 at:{0}", DateTime.Now.ToLongTimeString()));
            IsWorker1Busy = true;
            ((DelegateCommand)Worker1Command).RaiseCanExecuteChanged();
            Task.Factory.StartNew((Action)(() =>
            {
                var longRunningTaskWithTimeout = new Task<string>(() =>
                {
                    return engineSimulator.GetDataWithLongTime();
                }, TaskCreationOptions.LongRunning);

                longRunningTaskWithTimeout.Start();
                int miliSec = 5000;
                if (longRunningTaskWithTimeout.Wait(miliSec))
                {
                    synchronizationContext.Post(s =>
                    {
                        Worker1StatusCollection.Add(string.Format("Task completed with allotted time:{0}s" + miliSec / 1000));
                        Worker1StatusCollection.Add("Task Status:" + longRunningTaskWithTimeout.Status.ToString());
                        Worker1StatusCollection.Add("ResultFromEngine:"+longRunningTaskWithTimeout.Result);
                        Worker1StatusCollection.Add(string.Format("End Worker1 at:{0}", DateTime.Now.ToLongTimeString()));
                        IsWorker1Busy = false;
                        ((DelegateCommand)Worker1Command).RaiseCanExecuteChanged();
                    }, null);
                }
                else
                {
                    synchronizationContext.Post(s =>
                    {
                        Worker1StatusCollection.Add(string.Format("Task Not completed with allotted time:{0}s", miliSec / 1000));
                        Worker1StatusCollection.Add("Status:" + longRunningTaskWithTimeout.Status.ToString());
                        Worker1StatusCollection.Add(string.Format("End Worker1 at:{0}", DateTime.Now.ToLongTimeString()));
                        IsWorker1Busy = false;
                        ((DelegateCommand)Worker1Command).RaiseCanExecuteChanged();
                    }, null);
                }
            }));
        }
        private bool isWorker1Busy;
        public bool IsWorker1Busy
        {
            get { return isWorker1Busy; }
            set { PropertyChanged.ChangeAndNotify(ref isWorker1Busy, value, () => IsWorker1Busy); }
        }
        public ICommand Worker1Command { get; private set; }
        #endregion

        #region Worker2
        private ObservableCollection<string> worker2StatusCollection;
        public ObservableCollection<string> Worker2StatusCollection
        {
            get { return worker2StatusCollection; }
            set { PropertyChanged.ChangeAndNotify(ref worker2StatusCollection, value, () => Worker2StatusCollection); }
        }
        public void Worker2()
        {
            Worker2StatusCollection.Add(string.Format("Start Worker2 at:{0}", DateTime.Now.ToLongTimeString()));
            IsWorker2Busy = true;
            ((DelegateCommand)Worker2Command).RaiseCanExecuteChanged();
            Task.Factory.StartNew((Action)(() =>
            {
                var longRunningTaskWithTimeout = new Task<string>(() =>
                {
                    return engineSimulator.GetDataWithLongTime();
                }, TaskCreationOptions.LongRunning);

                longRunningTaskWithTimeout.Start();
                int miliSec = 11000;
                if (longRunningTaskWithTimeout.Wait(miliSec))
                {
                    synchronizationContext.Post(s =>
                    {
                        Worker2StatusCollection.Add(string.Format("Task completed with allotted time:{0}s", miliSec / 1000));
                        Worker2StatusCollection.Add("Tast Status:" + longRunningTaskWithTimeout.Status.ToString());
                        Worker2StatusCollection.Add("ResultFromEngine:" + longRunningTaskWithTimeout.Result);
                        Worker2StatusCollection.Add(string.Format("End Worker2 at:{0}", DateTime.Now.ToLongTimeString()));
                        IsWorker2Busy = false;
                        ((DelegateCommand)Worker2Command).RaiseCanExecuteChanged();
                    }, null);
                }
                else
                {
                    synchronizationContext.Post(s =>
                    {
                        Worker2StatusCollection.Add(string.Format("Task Not completed with allotted time:{0}s", miliSec / 1000));
                        Worker2StatusCollection.Add("Task Status:" + longRunningTaskWithTimeout.Status.ToString());
                        Worker2StatusCollection.Add(string.Format("End Worker2 at:{0}", DateTime.Now.ToLongTimeString()));
                        IsWorker2Busy = false;
                        ((DelegateCommand)Worker2Command).RaiseCanExecuteChanged();
                    }, null);
                }
            }));
        }
        private bool isWorker2Busy;
        public bool IsWorker2Busy
        {
            get { return isWorker2Busy; }
            set { PropertyChanged.ChangeAndNotify(ref isWorker2Busy, value, () => IsWorker2Busy); }
        }
        public ICommand Worker2Command { get; private set; }
        #endregion

        #region Worker3
        private ObservableCollection<string> worker3StatusCollection;
        public ObservableCollection<string> Worker3StatusCollection
        {
            get { return worker3StatusCollection; }
            set { PropertyChanged.ChangeAndNotify(ref worker3StatusCollection, value, () => Worker3StatusCollection); }
        }
        public void Worker3()
        {
            Worker3StatusCollection.Add(string.Format("Start Worker3 at:{0}", DateTime.Now.ToLongTimeString()));
            IsWorker3Busy = true;
            ((DelegateCommand)Worker3Command).RaiseCanExecuteChanged();
            Task.Factory.StartNew((Action)(() =>
            {
                var longRunningTaskWithTimeout = new Task<string>(() =>
                {
                    return engineSimulator.GetDataWithShortTime();
                }, TaskCreationOptions.LongRunning);

                longRunningTaskWithTimeout.Start();
                int miliSec = 1000;
                if (longRunningTaskWithTimeout.Wait(miliSec))
                {
                    synchronizationContext.Post(s =>
                    {
                        Worker3StatusCollection.Add(string.Format("Task completed with allotted time:{0}s", miliSec / 1000));
                        Worker3StatusCollection.Add("Task Status:" + longRunningTaskWithTimeout.Status.ToString());
                        Worker3StatusCollection.Add("ResultFromEngine:" + longRunningTaskWithTimeout.Result);
                        Worker3StatusCollection.Add(string.Format("End Worker3 at:{0}", DateTime.Now.ToLongTimeString()));
                        IsWorker3Busy = false;
                        ((DelegateCommand)Worker3Command).RaiseCanExecuteChanged();
                    }, null);
                }
                else
                {
                    synchronizationContext.Post(s =>
                    {
                        Worker3StatusCollection.Add(string.Format("Task Not completed with allotted time:{0}", miliSec / 1000));
                        Worker3StatusCollection.Add("Status:" + longRunningTaskWithTimeout.Status.ToString());
                        Worker3StatusCollection.Add(string.Format("End Worker3 at:{0}", DateTime.Now.ToLongTimeString()));
                        IsWorker3Busy = false;
                        ((DelegateCommand)Worker3Command).RaiseCanExecuteChanged();
                    }, null);
                }
            }));
        }
        private bool isWorker3Busy;
        public bool IsWorker3Busy
        {
            get { return isWorker3Busy; }
            set { PropertyChanged.ChangeAndNotify(ref isWorker3Busy, value, () => IsWorker3Busy); }
        }
        public ICommand Worker3Command { get; private set; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
