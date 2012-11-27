namespace KSS.HorseRacing.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required(ErrorMessage = "���� ����� ����������� � ����������!")]        
        public string Username { get; set; }

        [Required(ErrorMessage = "���� ������ ����������� � ����������!")]        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string MessageToShowAbove { get; set; }
    }
}