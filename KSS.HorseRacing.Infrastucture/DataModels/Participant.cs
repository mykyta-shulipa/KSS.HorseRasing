namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Participant : BaseEntity
    {
        public int NumberInRace { get; set; }

        public int PlaceInRace { get; set; }

        public virtual Race Race { get; set; }

        public virtual Racer Racer { get; set; }

        [Column("Id_Race")]
        public int RaceId { get; set; }

        [Column("Id_Racer")]
        public int RacerId { get; set; }
    }
}