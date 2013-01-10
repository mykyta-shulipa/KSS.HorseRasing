namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RaceDetailsViewModel
    {
        public int RaceId { get; set; }

        [Display(Name = "���� ������")]
        public string DateTimeOfRace { get; set; }

        [Display(Name = "����� ������")]
        public string NumberRaceInDay { get; set; }

        public IList<ParticipantViewModel> Participants { get; set; }
    }
}