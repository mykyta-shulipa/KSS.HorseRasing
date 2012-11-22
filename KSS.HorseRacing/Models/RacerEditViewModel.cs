namespace KSS.HorseRacing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    public class RacerEditViewModel
    {
        public IEnumerable<SelectListItem> ListHorsesForDropDown { get; set; }

        [DisplayName("Horse")]
        public int SelectedHorseId { get; set; }

        public IEnumerable<SelectListItem> ListJockeysForDropDown { get; set; }

        [DisplayName("Jockey")]
        public int SelectedJockeyId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}