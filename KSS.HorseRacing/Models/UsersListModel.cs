namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;

    public class UsersListModel
    {
        [DisplayName("#")]
        public int UserId { get; set; }

        [DisplayName("User Name")]
        public string Username { get; set; }

        [DisplayName("User Role Name")]
        public string RoleName { get; set; }
    }
}