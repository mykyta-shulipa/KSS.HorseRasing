namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;

    public class RacerViewModel
    {
        [DisplayName("#")]
        public int RacerId { get; set; }

        [DisplayName("Полное имя жокея")]
        //[DisplayName("Jokey's Full Name")]
        public string JokeyName { get; set; }

        [DisplayName("Псевдоним жокея")]
        //[DisplayName("Jokey's Alias")]
        public string JockeyAlias { get; set; }

        [DisplayName("Кличка лошади")]
        //[DisplayName("Horse's Nickname")]
        public string HorseNickname { get; set; }

        //[DisplayName("Together from")]
        [DisplayName("Вместе с")]
        public string RacerDateTimeStart { get; set; }

        //[DisplayName("Together to")]
        [DisplayName("Вместе до")]
        public string RacerDateTimeEnd { get; set; }

        public int JokeyId { get; set; }

        public int HorseId { get; set; }
    }
}