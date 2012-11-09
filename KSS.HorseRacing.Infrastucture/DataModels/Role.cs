namespace KSS.HorseRacing.Infrastucture.DataModels
{
    public class Role : BaseEntity
    {
        public const string ADMIN = "admin";

        public const string USER = "user";

        public const string JUDGE = "judge";

        public string Name { get; set; }
    }
}