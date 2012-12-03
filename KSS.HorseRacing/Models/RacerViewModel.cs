namespace KSS.HorseRacing.Models
{
    using System.ComponentModel;

    public class RacerViewModel
    {
        [DisplayName("#")]
        public int RacerId { get; set; }

        [DisplayName("������ ��� �����")]
        //[DisplayName("Jokey's Full Name")]
        public string JokeyName { get; set; }

        [DisplayName("��������� �����")]
        //[DisplayName("Jokey's Alias")]
        public string JockeyAlias { get; set; }

        [DisplayName("������ ������")]
        //[DisplayName("Horse's Nickname")]
        public string HorseNickname { get; set; }

        //[DisplayName("Together from")]
        [DisplayName("������ �")]
        public string RacerDateTimeStart { get; set; }

        //[DisplayName("Together to")]
        [DisplayName("������ ��")]
        public string RacerDateTimeEnd { get; set; }

        public int JokeyId { get; set; }

        public int HorseId { get; set; }
    }
}