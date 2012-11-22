namespace KSS.HorseRacing.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Models;

    public class RacerService
    {
        public IList<RacerViewModel> GetListRacers()
        {
            var list = new List<RacerViewModel>();
            using (var unit = new UnitOfWork())
            {
                var racers = unit.Racer.LoadRacers(new RacerFilter { IsActiveNow = true });
                list.AddRange(racers.Select(getRacerViewModel));
                return list;
            }
        }

        public RacerViewModel GetRacerDetails(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var racer = unit.Racer.Get(id);
                var model = getRacerViewModel(racer);
                return model;
            }
        }

        public RacerCreateViewModel GetRacerCreateViewModel()
        {
            var model = new RacerCreateViewModel();
            using (var unit = new UnitOfWork())
            {
                var horses = unit.Horse.GetAllHorses();
                var jockeys = unit.Jockey.GetAllJockeys();
                var listHorses = horses.Select(horse =>
                        new SelectListItem
                        {
                            Value = horse.Id.ToString(CultureInfo.InvariantCulture),
                            Text = horse.Nickname
                        });
                var listJockeys = jockeys.Select(jockey =>
                        new SelectListItem
                        {
                            Value = jockey.Id.ToString(CultureInfo.InvariantCulture),
                            Text = jockey.Alias
                        });
                model.ListHorsesForDropDown = listHorses;
                model.ListJockeysForDropDown = listJockeys;
            }

            return model;
        }

        public void AddNewRacer(RacerCreateViewModel model)
        {
            using (var unit = new UnitOfWork())
            {
                var horse = unit.Horse.Get(model.SelectedHorseId);
                var jockey = unit.Jockey.Get(model.SelectedJockeyId);
                var racer = new Racer
                {
                    Horse = horse, 
                    Jockey = jockey                                        
                };
                unit.Racer.Save(racer);
            }
        }

        private RacerViewModel getRacerViewModel(Racer racer)
        {
            var model = new RacerViewModel
            {
                RacerId = racer.Id,
                JokeyName = racer.Jockey.FullName,
                JokeyId = racer.Jockey.Id,
                HorseId = racer.Horse.Id,
                HorseNickname = racer.Horse.Nickname,
                RacerDateTimeStart = racer.DateTimeStart.ToString(CultureInfo.InvariantCulture),
                RacerDateTimeEnd = racer.DateTimeEnd.HasValue 
                    ? ((DateTime)racer.DateTimeEnd).ToString(CultureInfo.InvariantCulture) 
                    : "-"
            };
            return model;
        }
    }
}