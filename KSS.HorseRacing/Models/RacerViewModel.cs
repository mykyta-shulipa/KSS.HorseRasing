namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;

    public class RacerViewModel
    {
        [DisplayName("#")]
        public int RacerId { get; set; }

        [DisplayName("Jokey's Full Name")]
        public string JokeyName { get; set; }

        [DisplayName("Jokey's Alias")]
        public string JockeyAlias { get; set; }

        [DisplayName("Horse's Nickname")]
        public string HorseNickname { get; set; }

        [DisplayName("Together from")]
        public string RacerDateTimeStart { get; set; }

        [DisplayName("Together to")]
        public string RacerDateTimeEnd { get; set; }

        public int JokeyId { get; set; }

        public int HorseId { get; set; }
    }
}