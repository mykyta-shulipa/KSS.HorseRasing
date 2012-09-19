namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System;

    public class Jockey : BaseEntity
    {
        public string Alias { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }
    }    
}
