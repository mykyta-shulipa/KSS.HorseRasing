namespace KSS.HorseRacing.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WinnerJockeyForYearViewModel
    {
        public int JockeyId { get; set; }

        [Display(Name = "Полное имя жокея")]
        public string JockeyFullName { get; set; }

        [Display(Name = "Псевдоним жокея")]
        public string JockeyAlias { get; set; }

        [Display(Name = "Количество выигранных заездов (1, 2 или 3 место)")]
        public int QuantityWinnerRaces { get; set; }
    }
}