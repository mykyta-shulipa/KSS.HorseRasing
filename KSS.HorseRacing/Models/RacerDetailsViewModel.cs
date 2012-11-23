namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;

    public class RacerDetailsViewModel
    {
        public int RacerId { get; set; }

        [DisplayName("Horse Nickname")]
        public string HorseNickname { get; set; }

        [DisplayName("Jockey Full Name")]
        public string JokeyFullName { get; set; }

        [DisplayName("Jockey Alias")]
        public string JockeyAlias { get; set; }

        [DisplayName("Together From")]
        public string RacerDateTimeStart { get; set; }

        [DisplayName("Together To")]
        public string RacerDateTimeEnd { get; set; }
    }
}