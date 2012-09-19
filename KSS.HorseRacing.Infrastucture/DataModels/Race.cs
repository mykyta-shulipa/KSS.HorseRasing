namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System;
    using System.Collections.Generic;

    public class Race : BaseEntity
    {
        public DateTime DateTimeOfRace { get; set; }

        public int NumberRaceInDay { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}
