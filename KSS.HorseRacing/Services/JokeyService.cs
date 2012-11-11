namespace KSS.HorseRacing.Services
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public class JokeyService
    {
        public IList<Jockey> GetListJokeys()
        {
            using (var unit = new UnitOfWork())
            {
                var jockeys = unit.Jockey.GetAllJockeys();
                return jockeys;
            }
        }
    }
}