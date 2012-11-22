namespace KSS.HorseRacing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    public class RacerEditViewModel
    {
        public int RacerId { get; set; }

        public IEnumerable<SelectListItem> ListHorsesForDropDown { get; set; }

        [DisplayName("Horse")]
        public int SelectedHorseId { get; set; }

        public IEnumerable<SelectListItem> ListJockeysForDropDown { get; set; }

        [DisplayName("Jockey")]
        public int SelectedJockeyId { get; set; }

        [DisplayName("Together from")]
        public DateTime StartDateTime { get; set; }

        [DisplayName("Together to")]
        public DateTime? EndDateTime { get; set; }
    }
}