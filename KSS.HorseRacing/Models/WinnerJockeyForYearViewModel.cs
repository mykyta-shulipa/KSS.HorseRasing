namespace KSS.HorseRacing.Models
{
    public class WinnerJockeyForYearViewModel
    {
        public int JockeyId { get; set; }

        public string JockeyFullName { get; set; }

        public string JockeyAlias { get; set; }

        public int QuantityWinnerRaces { get; set; }
    }
}