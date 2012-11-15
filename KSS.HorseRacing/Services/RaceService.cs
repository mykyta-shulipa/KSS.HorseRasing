namespace KSS.HorseRacing.Services
{
    using KSS.HorseRacing.Controllers;
    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Models;

    public class RaceService
    {
        public ListRacesViewModel GetListRaces()
        {
            using (var unit = new UnitOfWork())
            {
                var allRaces = unit.Race.GetAllRaces();
                var model = new ListRacesViewModel { Races = allRaces };
                return model;
            }
        }
    }
}