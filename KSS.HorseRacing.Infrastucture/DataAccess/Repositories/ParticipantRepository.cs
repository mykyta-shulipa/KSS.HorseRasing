using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;
using KSS.HorseRacing.Infrastucture.DataModels;
using KSS.HorseRacing.Infrastucture.Extensions;

namespace KSS.HorseRacing.Infrastucture.DataAccess.Repositories
{
    public class ParticipantRepository : BaseRepository, IParticipantRepository
    {
        public List<Participant> LoadParticipants(ParticipantFilter filter)
        {
            var queryable = getContext().Participants
                .WhereIf(filter.Id.HasValue, x => x.Id == filter.Id)
                .WhereIf(filter.RaceId.HasValue, x => x.Race.Id == filter.RaceId);

            if (filter.WithRacer)
            {
                queryable = queryable.Include(x => x.Racer);
            }

            if (filter.WithJockey)
            {
                queryable = queryable.Include(x => x.Racer.Jockey);
            }

            if (filter.WithHorse)
            {
                queryable = queryable.Include(x => x.Racer.Horse);
            }

            var list = queryable.ToList();
            return list;
        }

        public void Save(Participant participant)
        {
            save(participant);
        }
    }
}