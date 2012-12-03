namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;

    public class RacerDetailsViewModel
    {
        public int RacerId { get; set; }

        //[DisplayName("Horse Nickname")]
        [DisplayName("Кличка лошади")]
        public string HorseNickname { get; set; }

        [DisplayName("Полное имя жокея")]
        //[DisplayName("Jockey Full Name")]
        public string JokeyFullName { get; set; }

        [DisplayName("Псевдоним жокея")]
        //[DisplayName("Jockey Alias")]
        public string JockeyAlias { get; set; }

        //[DisplayName("Together From")]
        [DisplayName("Вместе с ")]
        public string RacerDateTimeStart { get; set; }

        //[DisplayName("Together To")]
        [DisplayName("Вместе до")]
        public string RacerDateTimeEnd { get; set; }
    }
}