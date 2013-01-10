using System.ComponentModel;

namespace KSS.HorseRacing.Models
{
    public class WinnersViewModel
    {
        [DisplayName("������ ������")]
        public string HorseNickname { get; set; }

        [DisplayName("��������� �����")]
        public string JockeyAlias { get; set; }

        [DisplayName("���������� ������� � ��������� �������")]
        public int CountWinnerRaces { get; set; }
    }
}