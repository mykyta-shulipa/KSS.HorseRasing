namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;

    public class RaceViewModel
    {
        public int RaceId { get; set; }

        public string RaceDateTime { get; set; }

        public string RaceNumberInDay { get; set; }

        public IList<ParticipantViewModel> Participants { get; set; }
    }
}