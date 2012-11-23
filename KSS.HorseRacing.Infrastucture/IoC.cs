namespace KSS.HorseRacing
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Practices.Unity;

    public static class IoC
    {
        /// <summary>
        /// The Unity container.
        /// </summary>
        private static readonly IUnityContainer _container = new UnityContainer();

        /// <summary>
        /// The resolve.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// The System.Object.
        /// </returns>
        public static object Resolve(Type type)
        {            
            return _container.Resolve(type);
        }

        /// <summary>
        /// The resolve.
        /// </summary>
        /// <typeparam name="T">
        /// The type to resolve.
        /// </typeparam>
        /// <returns>
        /// The resolved type.
        /// </returns>
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// The resolve all.
        /// </summary>
        /// <typeparam name="T">
        /// The type to resolve.
        /// </typeparam>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; T].
        /// </returns>
        public static IEnumerable<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>();
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="name">
        /// The name of connection between interface and type.
        /// </param>
        /// <typeparam name="TI">
        /// The interface to bind.
        /// </typeparam>
        /// <typeparam name="T">
        /// The type to bind.
        /// </typeparam>
        public static void Register<TI, T>(string name = null) where T : TI
        {
            if (name == null)
            {
                _container.RegisterType<TI, T>();
            }
            else
            {
                _container.RegisterType<TI, T>(name);
            }
        }

        public static void RegisterType(Type type)
        {
            _container.RegisterType(type);
        }

        /// <summary>
        /// The register single instance.
        /// </summary>
        /// <typeparam name="T">
        /// The type to register.
        /// </typeparam>
        public static void RegisterSingleInstance<T>() where T : class
        {
            _container.RegisterType<T>(new ContainerControlledLifetimeManager());
        }
    }
}
