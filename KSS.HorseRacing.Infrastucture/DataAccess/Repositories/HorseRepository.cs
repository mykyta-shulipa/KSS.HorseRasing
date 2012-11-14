namespace KSS.HorseRacing.Infrastucture.DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public class HorseRepository : BaseRepository, IHorseRepository
    {
        public IList<Horse> GetAllHorses()
        {
            var horses = getContext().Horses.ToList();
            return horses;
        }

        public Horse Get(int id)
        {
            var horse = getContext().Horses.FirstOrDefault(x => x.Id == id && x.IsActive);
            return horse;
        }

        public void Save(Horse horse)
        {
            horse.IsActive = true;
            save(horse);
        }

        public void Delete(Horse horse)
        {
            horse.IsActive = false;
            save(horse);
        }
    }
}