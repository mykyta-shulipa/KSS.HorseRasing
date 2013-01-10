namespace KSS.HorseRacing.Infrastucture.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
    using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;
    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Infrastucture.Extensions;

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

        public List<Race> LoadRaces(RaceFilter filter)
        {
            var races = getContext().Races
                 .WhereIf(filter.Id.HasValue, x => x.Id == filter.Id)
                 .WhereIf(filter.DateOfRace.HasValue, x => x.DateTimeOfRace.Date == ((DateTime)filter.DateOfRace).Date)
                 .WhereIf(filter.RaceNumberInDay > 0, x => x.NumberRaceInDay == filter.RaceNumberInDay);

            return races.ToList();
        }

        public Race GetRace(DateTime raceDate, int raceNumber)
        {
            var endDateTime = raceDate.AddDays(1).AddSeconds(-1);
            var startDateTime = raceDate.AddDays(-1).AddSeconds(1);
            var race = getContext().Races
                .FirstOrDefault(x => x.DateTimeOfRace > startDateTime && x.DateTimeOfRace < endDateTime && x.NumberRaceInDay == raceNumber);
            return race;
        }

        public List<Race> GetRacesListForMonth(DateTime yearAndMonth)
        {
            var startDateTime = new DateTime(yearAndMonth.Year, yearAndMonth.Month, 1, 0,0,1);
            var endDateTime = startDateTime.AddMonths(1).AddSeconds(-1);
            var races = getContext().Races
                .Where(x => x.DateTimeOfRace > startDateTime && x.DateTimeOfRace < endDateTime)
                .ToList();
            return races;
        }
    }
}