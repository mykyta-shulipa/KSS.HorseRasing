using System.ComponentModel.DataAnnotations;

namespace KSS.HorseRacing.Models
{
    public class UserDetailsModel
    {
        [Display(Name = "#")]
        public int UserId { get; set; }

        [Display(Name = "Имя пользователя")]
        public string Username { get; set; }

        [Display(Name = "Роль пользователя")]
        public string UserRoleName { get; set; }
    }
}