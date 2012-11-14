namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System;
    using System.Collections.Generic;

    public class Racer : BaseEntity
    {
        public virtual Jockey Jockey { get; set; }

        public virtual Horse Horse { get; set; }

        public DateTime DateTimeStart { get; set; }

        public DateTime DateTimeEnd { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}