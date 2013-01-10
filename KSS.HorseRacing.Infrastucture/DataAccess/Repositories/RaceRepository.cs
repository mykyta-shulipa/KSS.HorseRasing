namespace KSS.HorseRacing.Infrastucture.DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public class RaceRepository : BaseRepository, IRaceRepository
    {
        public List<Race> GetAllRaces()
        {
            var races = getContext().Races.ToList();
            return races;
        }

        public void Save(Race race)
        {
            save(race);
        }

        public Race Get(int id)
        {
            var race = getContext().Races.FirstOrDefault(x => x.Id == id);
            return race;
        }

        public void Delete(Race race)
        {
            delete(race);
        }
    }
}