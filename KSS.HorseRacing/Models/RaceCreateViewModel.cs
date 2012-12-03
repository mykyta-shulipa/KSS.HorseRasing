using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KSS.HorseRacing.Models
{
    public class RaceCreateViewModel
    {
        public DateTime DateTimeOfRace { get; set; }

        public int NumberRaceInDay { get; set; }

        public IEnumerable<SelectListItem> ListParticipantsForDropdown { get; set; }
    }
}