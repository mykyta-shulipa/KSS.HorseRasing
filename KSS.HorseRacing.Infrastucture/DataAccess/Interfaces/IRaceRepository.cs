namespace KSS.HorseRacing.Infrastucture.DataAccess.Interfaces
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataModels;

    public interface IRaceRepository : IBaseRepository
    {
        List<Race> GetAllRaces();

        void Save(Race race);

        Race Get(int id);
    }
}