namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System;

    public class Race : BaseEntity
    {
        public DateTime DateTimeOfRace { get; set; }

        public int NumberRaceInDay { get; set; }
    }
}
