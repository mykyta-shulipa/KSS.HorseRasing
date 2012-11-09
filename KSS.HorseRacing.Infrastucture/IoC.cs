namespace KSS.HorseRacing.Infrastucture
{
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using KSS.HorseRacing.Infrastucture.Security;

    public static class IoC
    {
        private static IContainer _container;

        public static T Resolve<T>()
        {
            if (_container == null)
            {
                build();
            }

            return _container.Resolve<T>();
        }

        private static void build()
        {

            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.Register(c => new CryptoProviderMd5()).As<ICryptoProvider>().InstancePerHttpRequest();            
            builder.RegisterFilterProvider();
            _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}
