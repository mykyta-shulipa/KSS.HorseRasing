namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RaceDetailsViewModel
    {
        [Display(Name = "Дата заезда")]
        public string DateTimeOfRace { get; set; }

        [Display(Name = "Номер заезда")]
        public string NumberRaceInDay { get; set; }

        public IList<ParticipantViewModel> Participants { get; set; }
    }
}