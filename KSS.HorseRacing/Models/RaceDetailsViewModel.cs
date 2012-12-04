namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RaceDetailsViewModel
    {
        public int RaceId { get; set; }

        [Display(Name = "Дата заезда")]
        public string DateTimeOfRace { get; set; }

        [Display(Name = "Номер заезда")]
        public string NumberRaceInDay { get; set; }

        public IList<ParticipantViewModel> Participants { get; set; }
    }
}