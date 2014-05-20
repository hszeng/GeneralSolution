using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace WPF.MVVMDemo
{
    public static class CommandBehaviors
    {
        public static ICommand GetWindowLoadCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(WindowLoadCommandProperty);
        }
        public static void SetWindowLoadCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(WindowLoadCommandProperty, value);
        }
        // Using a DependencyProperty as the backing store for WindowLoadCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowLoadCommandProperty =
            DependencyProperty.RegisterAttached("WindowLoadCommand", typeof(ICommand), typeof(CommandBehaviors), new PropertyMetadata(null, OnWindowLoadedCommandPropertyChanged));
        public static void OnWindowLoadedCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = d as FrameworkElement;
            if (frameworkElement != null && e.NewValue is ICommand)
            {
                frameworkElement.Loaded
                  += (obj, args) =>
                     {
                         if ((e.NewValue as ICommand).CanExecute(obj))
                         {
                             (e.NewValue as ICommand).Execute(null);
                         }
                     };
            }
        }
    }
}
