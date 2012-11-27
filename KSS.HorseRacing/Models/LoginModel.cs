namespace KSS.HorseRacing.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required(ErrorMessage = "Поле Логин обязательно к заполнению!")]        
        public string Username { get; set; }

        [Required(ErrorMessage = "Поле Пароль обязательно к заполнению!")]        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string MessageToShowAbove { get; set; }
    }
}