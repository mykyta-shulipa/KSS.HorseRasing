using System.ComponentModel.DataAnnotations;

namespace KSS.HorseRacing.Models
{
    public class UserDetailsModel
    {
        [Display(Name = "#")]
        public int UserId { get; set; }

        [Display(Name = "��� ������������")]
        public string Username { get; set; }

        [Display(Name = "���� ������������")]
        public string UserRoleName { get; set; }
    }
}