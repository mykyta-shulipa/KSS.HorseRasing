namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System;

    public class Horse : BaseEntity
    {
        public string Nickname { get; set; }

        public DateTime DateBirth { get; set; }
    }
}
