namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class RacerCreateViewModel
    {
        public IEnumerable<SelectListItem> ListHorsesForDropDown { get; set; }

        public int SelectedHorseId { get; set; }

        public IEnumerable<SelectListItem> ListJockeysForDropDown { get; set; }

        public int SelectedJockeyId { get; set; }
    }
}