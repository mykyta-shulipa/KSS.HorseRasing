namespace KSS.HorseRacing.Infrastucture.DataAccess.Filters
{
    public class ParticipantFilter : BaseFilter
    {
        public int? RaceId { get; set; }

        public bool WithRacer { get; set; }

        public bool WithHorse { get; set; }

        public bool WithJockey { get; set; }

        public bool WithRacerHorceAndJockey { get; set; }
    }
}