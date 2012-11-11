namespace KSS.HorseRacing.Infrastucture
{
    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;
    using KSS.HorseRacing.Infrastucture.DataAccess.Repositories;
    using KSS.HorseRacing.Infrastucture.Security;

    public static class InfrastructureDiConfig
    {
        public static void Register()
        {
            IoC.Register<ICryptoProvider, CryptoProviderMd5>("crypto");
            IoC.Register<ICryptoProvider, CryptoProviderMd5>();
            IoC.Register<IUserRepository, UserRepository>();
            IoC.RegisterType(typeof(EfContext));
        }
    }
}