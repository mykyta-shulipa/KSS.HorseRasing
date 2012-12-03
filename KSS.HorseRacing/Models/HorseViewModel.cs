namespace KSS.HorseRacing.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class HorseViewModel
    {
        private const string MESSAGE = "Поле {1} обязательно к заполнению!";

        [DisplayName("#")]
        public int HorseId { get; set; }

        [Required(ErrorMessage = "Поле Кличка обязательно к заполнению!")]
        //[DisplayName("Nickname")]
        [DisplayName("Кличка")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Поле Дата Рождения обязательно к заполнению!")]
        //[DisplayName("Date of Birth")]
        [DisplayName("Дата рождения")]
        public DateTime DateBirth { get; set; }
    }
}