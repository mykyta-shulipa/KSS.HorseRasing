namespace KSS.HorseRacing.Infrastucture.DataAccess.Filters
{
    using System;

    public class RacerFilter : BaseFilter
    {
        public bool? IsActiveNow { get; set; }

        public bool WithHorse { get; set; }

        public bool WithJockey { get; set; }

    }
}