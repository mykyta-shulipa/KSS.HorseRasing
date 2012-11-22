namespace KSS.HorseRacing.Infrastucture.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
    using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;
    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Infrastucture.Extensions;

    public class RacerRepository : BaseRepository, IRacerRepository
    {
        public Racer Get(int id)
        {
            var racer = getContext().Racers
                .Where(x => x.Id == id)
                .Include(x => x.Horse)
                .Include(x => x.Jockey)
                .FirstOrDefault();
            return racer;
        }

        public IEnumerable<Racer> LoadRacers(RacerFilter filter)
        {
            var racers = getContext().Racers
                .WhereIf(filter.IsActiveNow.HasValue && (bool)filter.IsActiveNow, x => x.DateTimeEnd < DateTime.Now);
            var list = racers.ToList();
            return list;
        }

        public void Save(Racer racer)
        {            
            save(racer);
        }
    }
}