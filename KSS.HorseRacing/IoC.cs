namespace KSS.HorseRacing
{
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using KSS.HorseRacing.Infrastucture;
    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;
    using KSS.HorseRacing.Infrastucture.Security;
    using KSS.HorseRacing.Services;

    public static class IoC
    {
        private static readonly ContainerBuilder _builder = new ContainerBuilder();
        private static IContainer _container;

        public static T Resolve<T>()
        {
            if (_container == null)
            {
                Build();
            }

            return _container.Resolve<T>();
        }

        public static void Build()
        {
            _builder.RegisterControllers(Assembly.GetExecutingAssembly());
            _builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IBaseRepository)), Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            _builder.Register(c => new CryptoProviderMd5()).As<ICryptoProvider>().InstancePerHttpRequest();
            _builder.Register(c => new EfContext()).As<EfContext>().InstancePerHttpRequest();            
            _builder.RegisterFilterProvider();
            _container = _builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}
