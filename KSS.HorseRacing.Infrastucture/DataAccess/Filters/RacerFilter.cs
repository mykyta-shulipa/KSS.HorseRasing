namespace KSS.HorseRacing.Infrastucture.DataAccess.Filters
{
    public class RacerFilter : BaseFilter
    {
        public bool? IsActiveNow { get; set; }

        public bool WithHorse { get; set; }
    }
}