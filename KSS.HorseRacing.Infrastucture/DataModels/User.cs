namespace KSS.HorseRacing.Infrastucture.DataModels
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public SecureCredentials Password { get; set; }

        public virtual Role UserRole { get; set; }
    }
}
