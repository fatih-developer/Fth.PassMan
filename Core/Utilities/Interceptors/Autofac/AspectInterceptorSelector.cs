using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using MainCore.Aspects.Autofac.Exception;
using MainCore.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace MainCore.Utilities.Interceptors.Autofac
{
    public class AspectInterceptorSelector:IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileAppenderLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();

        }
    }
}
