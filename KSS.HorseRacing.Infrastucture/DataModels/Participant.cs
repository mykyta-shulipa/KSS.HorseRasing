namespace KSS.HorseRacing.Infrastucture.DataModels
{
    public class Participant : BaseEntity
    {
        public int NumberInRace { get; set; }

        public int PlaceInRace { get; set; }

        public virtual Race Race { get; set; }
    }
}