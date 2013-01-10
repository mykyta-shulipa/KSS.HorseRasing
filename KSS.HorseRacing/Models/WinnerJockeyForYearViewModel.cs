namespace KSS.HorseRacing.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WinnerJockeyForYearViewModel
    {
        public int JockeyId { get; set; }

        [Display(Name = "������ ��� �����")]
        public string JockeyFullName { get; set; }

        [Display(Name = "��������� �����")]
        public string JockeyAlias { get; set; }

        [Display(Name = "���������� ���������� ������� (1, 2 ��� 3 �����)")]
        public int QuantityWinnerRaces { get; set; }
    }
}