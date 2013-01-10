namespace KSS.HorseRacing.Infrastucture.DataAccess.Interfaces
{
    using System;
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public interface IRaceRepository : IBaseRepository
    {
        List<Race> GetAllRaces();

        void Save(Race race);

        Race Get(int id);

        void Delete(Race race);

        List<Race> LoadRaces(RaceFilter filter);

        Race GetRace(DateTime raceDate, int raceNumber);

        List<Race> GetRacesListForMonth(DateTime yearAndMonth);
    }
}