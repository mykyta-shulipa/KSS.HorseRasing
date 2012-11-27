namespace KSS.HorseRacing.Models
{
    using System.ComponentModel.DataAnnotations;

    public class JockeyViewModel
    {
        public int JockeyId { get; set; }

        [Display(Name = "Псевдоним")]
        public string Alias { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Дата рождения")]
        public string DateBirth { get; set; }
    }
}