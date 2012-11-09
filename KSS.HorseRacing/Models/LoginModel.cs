namespace KSS.HorseRacing.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required]        
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string MessageToShowAbove { get; set; }
    }
}