namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class Role : BaseEntity
    {
        public const string ADMIN = "admin";

        public const string USER = "user";

        public const string JUDGE = "judge";

        [MaxLength(MAX_LENGTH_STRING)]
        public string Name { get; set; }
    }
}