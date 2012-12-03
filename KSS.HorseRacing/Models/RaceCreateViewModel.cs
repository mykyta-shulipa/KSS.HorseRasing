using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KSS.HorseRacing.Models
{
    public class RaceCreateViewModel
    {
        public string DateTimeOfRace { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Значение должно быть больше чем 0.")]
        public string NumberRaceInDay { get; set; }

        public IEnumerable<SelectListItem> ListParticipantsForDropdown { get; set; }

        public IEnumerable<ParticipantViewModel> Participants { get; set; }
    }
}