namespace KSS.HorseRacing.Infrastucture.DataModels
{
    public class Participant : BaseEntity
    {
        public int NumberInRace { get; set; }

        public int PlaceInRace { get; set; }

        public virtual Jockey Jockey { get; set; }

        public virtual Horse Horse { get; set; }
    }
}
