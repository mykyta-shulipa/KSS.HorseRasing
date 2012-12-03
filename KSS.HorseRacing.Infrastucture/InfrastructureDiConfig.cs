namespace KSS.HorseRacing.Infrastucture
{
    using DataAccess;
    using DataAccess.Interfaces;
    using DataAccess.Repositories;
    using Security;

    public static class InfrastructureDiConfig
    {
        public static void Register()
        {
            IoC.Register<ICryptoProvider, CryptoProviderMd5>("crypto");
            IoC.Register<ICryptoProvider, CryptoProviderMd5>();
            IoC.Register<IUserRepository, UserRepository>();
            IoC.Register<IHorseRepository, HorseRepository>();
            IoC.Register<IJockeyRepository, JockeyRepository>();
            IoC.Register<IRoleRepository, RoleRepository>();
            IoC.Register<IRacerRepository, RacerRepository>();
            IoC.Register<IRaceRepository, RaceRepository>();
            IoC.Register<IParticipantRepository, ParticipantRepository>();
            IoC.RegisterType(typeof(EfContext));
        }
    }
}