namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;

    public class UsersListModel
    {
        [DisplayName("#")]
        public int UserId { get; set; }

        //[DisplayName("User Name")]
        [DisplayName("��� ������������")]
        public string Username { get; set; }

        [DisplayName("���� ������������")]
        //[DisplayName("User Role Name")]
        public string RoleName { get; set; }
    }
}