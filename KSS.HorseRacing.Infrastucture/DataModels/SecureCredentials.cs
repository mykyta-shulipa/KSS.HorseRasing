namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class SecureCredentials
    {
        [Column("Salt")]
        public string Salt { get; set; }

        [Column("PasswordHash")]
        public string PasswordHash { get; set; }
    }
}