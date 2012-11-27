namespace KSS.HorseRacing.Models
{
    public class ParticipantViewModel
    {
        public int ParticipantId { get; set; }

        public int NumberInRace { get; set; }

        public int PlaceInRace { get; set; }

        public int JockeyId { get; set; }

        public string JockeyAlias { get; set; }

        public int HorseId { get; set; }

        public string HorseNickname { get; set; }
    }
}