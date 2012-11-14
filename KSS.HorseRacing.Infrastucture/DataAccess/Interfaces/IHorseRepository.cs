namespace KSS.HorseRacing.Infrastucture.DataAccess.Interfaces
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataModels;

    public interface IHorseRepository : IBaseRepository
    {
        IList<Horse> GetAllHorses();

        Horse Get(int id);

        void Save(Horse horse);

        void Delete(Horse horse);
    }
}