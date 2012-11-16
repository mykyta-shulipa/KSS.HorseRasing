namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;

    public class HorseViewModel
    {
        [DisplayName("#")]
        public int HorseId { get; set; }

        [DisplayName("Nickname")]
        public string Nickname { get; set; }

        [DisplayName("Date of Birth")]
        public string DateBirth { get; set; }
    }
}