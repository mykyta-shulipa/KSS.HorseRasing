namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : BaseEntity
    {
        [MaxLength(MAX_LENGTH_STRING)]
        public string Username { get; set; }

        public SecureCredentials Password { get; set; }

        public virtual Role Role { get; set; }

        [Column("Id_Role")]
        public int RoleId {get; set; }
    }
}
