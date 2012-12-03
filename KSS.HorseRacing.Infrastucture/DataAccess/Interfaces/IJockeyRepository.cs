namespace KSS.HorseRacing.Infrastucture.DataAccess.Interfaces
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataModels;

    public interface IJockeyRepository : IBaseRepository
    {
        IEnumerable<Jockey> GetAllJockeys();

        Jockey Get(int id);

        void Save(Jockey jockey);

        void Delete(Jockey jockey);
    }
}