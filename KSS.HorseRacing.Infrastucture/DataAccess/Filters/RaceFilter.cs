namespace KSS.HorseRacing.Infrastucture.DataAccess.Filters
{
    using System;

    public class RaceFilter : BaseFilter
    {
        public DateTime? DateOfRace { get; set; }

        public int RaceNumberInDay { get; set; }
    }
}