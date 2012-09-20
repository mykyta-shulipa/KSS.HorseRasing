namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System.Collections.Generic;

    public class Participant : BaseEntity
    {
        public int NumberInRace { get; set; }

        public int PlaceInRace { get; set; }

        public virtual Jockey Jockey { get; set; }

        public virtual Horse Horse { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
