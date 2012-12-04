namespace KSS.HorseRacing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;

    public class RaceCreateViewModel
    {
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [DataType(DataType.Date)]
        public string DateTimeOfRace { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Значение должно быть больше чем 0.")]
        public string NumberRaceInDay { get; set; }

        public IEnumerable<SelectListItem> ListParticipantsForDropdown { get; set; }

        public IEnumerable<ParticipantViewModel> Participants { get; set; }
    }
}