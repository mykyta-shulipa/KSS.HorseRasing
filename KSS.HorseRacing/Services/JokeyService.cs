namespace KSS.HorseRacing.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Models;

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

        public JockeyViewModel GetJockeyDetails(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var jockey = unit.Jockey.Get(id);
                var model = new JockeyViewModel
                {
                    Alias = jockey.Alias,
                    DateBirth = jockey.DateBirth.ToString(CultureInfo.InvariantCulture),
                    FirstName = jockey.FirstName,
                    LastName = jockey.LastName,
                    MiddleName = jockey.MiddleName
                };
                return model;
            }
        }

        public void AddNewJockey(JockeyViewModel model)
        {
            using (var unit = new UnitOfWork())
            {
                var jockey = new Jockey
                {
                    Alias = model.Alias,
                    DateBirth = DateTime.Parse(model.DateBirth),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName
                };
                unit.Jockey.Save(jockey);
            }
        }
    }
}