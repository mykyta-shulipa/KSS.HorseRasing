namespace KSS.HorseRacing.Infrastucture.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Jockey : BaseEntity
    {
        [MaxLength(MAX_LENGTH_STRING)]
        public string Alias { get; set; }

        [MaxLength(MAX_LENGTH_STRING)]
        public string FirstName { get; set; }

        [MaxLength(MAX_LENGTH_STRING)]
        public string MiddleName { get; set; }

        [MaxLength(MAX_LENGTH_STRING)]
        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public bool IsActive { get; set; }
        
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}
