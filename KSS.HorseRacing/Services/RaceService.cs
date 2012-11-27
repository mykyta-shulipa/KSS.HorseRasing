namespace KSS.HorseRacing.Services
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Models;

    public class RaceService
    {
        public IEnumerable<RaceViewModel> GetListRaces()
        {
            using (var unit = new UnitOfWork())
            {
                var allRaces = unit.Race.GetAllRaces();
                var list = new List<RaceViewModel>();
                foreach (var race in allRaces)
                {
                    list.Add(new RaceViewModel
                        {
                            RaceNumberInDay = race.NumberRaceInDay.ToString(),
                            RaceDateTime = race.DateTimeOfRace.ToShortDateString()
                        });
                }

                return list;
            }
        }
    }
}