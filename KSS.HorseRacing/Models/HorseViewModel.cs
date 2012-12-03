namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class HorseViewModel
    {
        private const string MESSAGE = "���� {1} ����������� � ����������!";

        [DisplayName("#")]
        public int HorseId { get; set; }

        [Required(ErrorMessage = "���� ������ ����������� � ����������!")]
        //[DisplayName("Nickname")]
        [DisplayName("������")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "���� ���� �������� ����������� � ����������!")]
        //[DisplayName("Date of Birth")]
        [DisplayName("���� ��������")]
        public string DateBirth { get; set; }
    }
}