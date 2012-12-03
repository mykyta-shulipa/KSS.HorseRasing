using System.ComponentModel.DataAnnotations;

namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;

    public class RaceViewModel
    {
        [Display(Name = "#")]
        public int RaceId { get; set; }

        [Display(Name = "Дата и время проведения")]
        public string RaceDateTime { get; set; }

        [Display(Name = "Номер гонки в этом дне")]
        public string RaceNumberInDay { get; set; }

        public IList<ParticipantViewModel> Participants { get; set; }
    }
}