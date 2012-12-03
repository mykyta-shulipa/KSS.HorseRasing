namespace KSS.HorseRacing.Infrastucture.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Filters;
    using Interfaces;
    using DataModels;
    using Extensions;

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
                .WhereIf(filter.IsActiveNow.HasValue && (bool)filter.IsActiveNow, x => x.DateTimeEnd > DateTime.Now);

            if (filter.WithHorse)
            {
                racers = racers.Include(x => x.Horse);
            }

            if (filter.WithJockey)
            {
                racers = racers.Include(x => x.Jockey);
            }

            var list = racers.ToList();
            return list;
        }

        public void Save(Racer racer)
        {
            save(racer);
        }
    }
}