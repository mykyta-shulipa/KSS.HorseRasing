namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Horse : BaseEntity
    {
        [MaxLength(MAX_LENGTH_STRING)]
        public string Nickname { get; set; }

        public DateTime DateBirth { get; set; }

        public bool IsActive { get; set; }
    }
}
