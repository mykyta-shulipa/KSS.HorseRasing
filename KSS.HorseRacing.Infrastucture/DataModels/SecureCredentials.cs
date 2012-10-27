namespace KSS.HorseRacing.Infrastucture.DataModels
{
    public class SecureCredentials
    {
        public string Salt { get; set; }

        public string PasswordHash { get; set; }
    }
}