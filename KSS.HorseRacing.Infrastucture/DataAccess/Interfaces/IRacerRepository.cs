namespace KSS.HorseRacing.Infrastucture.DataAccess.Interfaces
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public interface IRacerRepository : IBaseRepository
    {
        Racer Get(int id);

        IEnumerable<Racer> LoadRacers(RacerFilter filter);

        void Save(Racer racer);
    }
}