namespace KSS.HorseRacing.Configuration
{
    using KSS.HorseRacing.Infrastucture;

    public class WebDiConfig
    {        
        public static void Register()
        {
            InfrastructureDiConfig.Register();      
      
            IoC.RegisterType(typeof(SessionStorage));
        }
    }
}