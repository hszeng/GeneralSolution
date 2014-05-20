using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

namespace INotifyPropertyChangedDemo
{

    public class ViewModel1 : INotifyPropertyChanged
    {
        //private string _data;
        //public string Data
        //{

        //    get { return _data; }
        //    set
        //    {
        //        if (_data == value)
        //            return;
        //        _data = value;
        //        // Type un-safe PropertyChanged raise
        //        PropertyChanged(this, new PropertyChangedEventArgs("Data"));
        //    }
        //}
        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged = null;
        #endregion
        private string _data;
        public string Data
        {

            get { return _data; }
            set
            {
                PropertyChanged.ChangeAndNotify(ref _data, value, () => Data);
            }
        }
    }


    public static class PropertyChangedEventHandlerExtentions
    {
        public static bool ChangeAndNotify<T>(this PropertyChangedEventHandler handler, ref T field, T value, Expression<Func<T>> memberExpression)
        {
            if (memberExpression == null)
            {
                throw new ArgumentNullException("memberExpression");
            }
            // Retreive lambda body
            var body = memberExpression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("Lambda must return a property.");
            }
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                //值没有发生变化，不通知更新
                return false;
            }
            // Extract the right part (after "=>")
            var vmExpression = body.Expression as ConstantExpression;
            if (vmExpression != null)
            {
                // Create a reference to the calling object to pass it as the sender
                LambdaExpression lambda = Expression.Lambda(vmExpression);
                Delegate vmFunc = lambda.Compile();
                object sender = vmFunc.DynamicInvoke();

                if (handler != null)
                {
                    //body.Member.Name，Extract the name of the property to raise a change on
                    handler(sender, new PropertyChangedEventArgs(body.Member.Name));
                }
            }
            field = value;
            return true;
        }
    }


    public class Data : INotifyPropertyChanged
    {
        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        // props
        private string name;
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value, "Name"); }
        }
    }

    public class Data2 : INotifyPropertyChanged
    {
        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> selectorExpression)
        {
            if (selectorExpression == null)
                throw new ArgumentNullException("selectorExpression");
            MemberExpression body = selectorExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The body must be a member expression");
            OnPropertyChanged(body.Member.Name);
        }
        protected bool SetField<T>(ref T field, T value, Expression<Func<T>> selectorExpression)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(selectorExpression);
            return true;
        }
        // props
        private string name;
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value, () => Name); }
        }
    }
}
