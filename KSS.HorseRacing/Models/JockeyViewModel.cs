namespace KSS.HorseRacing.Models
{
    using System.ComponentModel.DataAnnotations;

    public class JockeyViewModel
    {
        public int JockeyId { get; set; }

        [Display(Name = "���������")]
        public string Alias { get; set; }

        [Display(Name = "���")]
        public string FirstName { get; set; }

        [Display(Name = "��������")]
        public string MiddleName { get; set; }

        [Display(Name = "�������")]
        public string LastName { get; set; }

        [Display(Name = "���� ��������")]
        public string DateBirth { get; set; }
    }
}