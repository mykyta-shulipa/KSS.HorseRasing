namespace KSS.HorseRacing.Infrastucture.DataModels
{
    public abstract class BaseEntity
    {
        public const int MAX_LENGTH_STRING = 255;

        public int Id { get; set; }
    }
}