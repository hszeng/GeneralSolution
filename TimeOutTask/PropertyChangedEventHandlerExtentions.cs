using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

namespace TimeOutTask
{
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
}
