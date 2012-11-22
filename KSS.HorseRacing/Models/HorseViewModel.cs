namespace KSS.HorseRacing.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class HorseViewModel
    {
        [DisplayName("#")]
        public int HorseId { get; set; }

        [Required]
        [DisplayName("Nickname")]
        public string Nickname { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateBirth { get; set; }
    }
}