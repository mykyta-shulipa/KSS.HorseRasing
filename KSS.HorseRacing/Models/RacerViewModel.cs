namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;

    public class RacerViewModel
    {
        [DisplayName("#")]
        public int RacerId { get; set; }

        [DisplayName("Jokey")]
        public string JokeyName { get; set; }
        
        [DisplayName("Horse")]
        public string HorseNickname { get; set; }

        [DisplayName("Together from")]
        public string RacerDateTimeStart { get; set; }

        [DisplayName("Together to")]
        public string RacerDateTimeEnd { get; set; }

        public int JokeyId { get; set; }

        public int HorseId { get; set; }
    }
}