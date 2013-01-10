using System.ComponentModel;

namespace KSS.HorseRacing.Models
{
    public class WinnersViewModel
    {
        [DisplayName("Кличка лошади")]
        public string HorseNickname { get; set; }

        [DisplayName("Псевдоним жокея")]
        public string JockeyAlias { get; set; }

        [DisplayName("Количество заездов с призовыми местами")]
        public int CountWinnerRaces { get; set; }
    }
}