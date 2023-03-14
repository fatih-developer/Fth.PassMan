using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Dals;
using DataAccess.Concrete.Mongo.Repositories;
using DataAccess.Concrete.Mongo.Settings;
using MongoDB.Driver;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<PasswordRepository>().As<IPasswordRepository>();
            builder.RegisterType<PasswordManager>().As<IPasswordService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<CalendarManager>().As<ICalendarService>();
            builder.RegisterType<EfCalendarDal>().As<IEfCalendarDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<IEfCustomerDal>();

            builder.RegisterType<ControlManager>().As<IControlService>();
            builder.RegisterType<EfControlDal>().As<IEfControlDal>();

            builder.RegisterType<ConnectionManager>().As<IConnectionService>();
            builder.RegisterType<EfConnectionDal>().As<IEfConnectionDal>();

            builder.RegisterType<PlanManager>().As<IPlanService>();
            builder.RegisterType<EfPlanDal>().As<IEfPlanDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
