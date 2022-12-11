using System;
using Castle.DynamicProxy;

namespace MainCore.Utilities.Interceptors.Autofac
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }


        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}