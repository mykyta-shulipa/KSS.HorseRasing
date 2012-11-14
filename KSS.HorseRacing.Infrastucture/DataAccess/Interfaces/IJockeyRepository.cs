namespace KSS.HorseRacing.Infrastucture.DataAccess.Interfaces
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataModels;

    public interface IJockeyRepository : IBaseRepository
    {
        IList<Jockey> GetAllJockeys();

        Jockey Get(int id);

        void Save(Jockey jockey);
    }
}