namespace KSS.HorseRacing.Services
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public class HorseService
    {
        public IList<Horse> GetListHorses()
        {
            using (var unit = new UnitOfWork())
            {
                var horses = unit.Horse.GetAllHorses();
                return horses;
            }
        }
    }
}