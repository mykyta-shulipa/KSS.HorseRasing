namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Racer : BaseEntity
    {
        public DateTime DateTimeStart { get; set; }

        public DateTime? DateTimeEnd { get; set; }

        [Column("Id_Jockey")]
        public int JockeyId { get; set; }

        public virtual Jockey Jockey { get; set; }

        [Column("Id_Horse")]
        public int HorseId { get; set; }

        public virtual Horse Horse { get; set; }
    }
}