namespace KSS.HorseRacing.Services
{
    using KSS.HorseRacing.Controllers;
    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Models;

    public class RaceService
    {
        public RaceViewModel GetListRaces()
        {
            using (var unit = new UnitOfWork())
            {
                var allRaces = unit.Race.GetAllRaces();
                var model = new RaceViewModel { Races = allRaces };
                return model;
            }
        }
    }
}