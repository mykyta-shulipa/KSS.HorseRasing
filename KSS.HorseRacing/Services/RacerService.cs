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
        private readonly GeneralService _generalService;

        public RacerService(GeneralService generalService)
        {
            _generalService = generalService;
        }

        public IList<RacerViewModel> GetListRacers()
        {
            var list = new List<RacerViewModel>();
            using (var unit = new UnitOfWork())
            {
                var racers = unit.Racer.LoadRacers(new RacerFilter { WithHorse = true });
                list.AddRange(racers.Select(getRacerViewModel));
                return list;
            }
        }

        public RacerDetailsViewModel GetRacerDetails(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var racer = unit.Racer.Get(id);
                var model = new RacerDetailsViewModel
                            {
                                RacerId = racer.Id,
                                HorseNickname = racer.Horse.Nickname,
                                JockeyAlias = racer.Jockey.Alias,
                                JokeyFullName = racer.Jockey.FullName,
                                RacerDateTimeEnd = racer.DateTimeEnd.HasValue ? ((DateTime)racer.DateTimeEnd).ToShortDateString() : "-",
                                RacerDateTimeStart = racer.DateTimeStart.ToShortDateString()
                            };
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
                var listHorses = getHorsesListForDropdown(horses);
                var listJockeys = getJockeysListForDropdown(jockeys);
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
                    Jockey = jockey,
                    DateTimeStart = model.StartDateTime
                };
                unit.Racer.Save(racer);
            }
        }

        public RacerEditViewModel GetRacerEditModel(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var racer = unit.Racer.Get(id);
                var horses = unit.Horse.GetAllHorses();
                var jockeys = unit.Jockey.GetAllJockeys();
                var model = new RacerEditViewModel
                {
                    RacerId = racer.Id,
                    StartDateTime = racer.DateTimeStart,
                    ListHorsesForDropDown = getHorsesListForDropdown(horses),
                    ListJockeysForDropDown = getJockeysListForDropdown(jockeys),
                    SelectedHorseId = racer.Horse.Id,
                    SelectedJockeyId = racer.Jockey.Id,
                    EndDateTime = racer.DateTimeEnd
                };
                return model;
            }
        }

        public void EditRacer(RacerEditViewModel model)
        {
            using (var unit = new UnitOfWork())
            {
                var racer = unit.Racer.Get(model.RacerId);
                if (racer.Horse.Id != model.SelectedHorseId)
                {
                    var horse = unit.Horse.Get(model.SelectedHorseId);
                    racer.Horse = horse;
                }

                if (racer.Jockey.Id != model.SelectedJockeyId)
                {
                    var jockey = unit.Jockey.Get(model.SelectedJockeyId);
                    racer.Jockey = jockey;
                }

                if (model.EndDateTime != null)
                {
                    racer.DateTimeEnd = model.EndDateTime;
                }

                racer.DateTimeStart = model.StartDateTime;
                unit.Racer.Save(racer);
            }
        }

        public RacerViewModel GetRacerViewModel(int racerId)
        {
            using (var unit = new UnitOfWork())
            {
                var racer = unit.Racer.Get(racerId);
                var model = getRacerViewModel(racer);
                return model;
            }
        }

        private RacerViewModel getRacerViewModel(Racer racer)
        {
            var model = new RacerViewModel
            {
                RacerId = racer.Id,
                JockeyAlias = racer.Jockey.Alias,
                JokeyName = racer.Jockey.FullName,
                JokeyId = racer.Jockey.Id,
                HorseId = racer.Horse.Id,
                HorseNickname = racer.Horse.Nickname,
                RacerDateTimeStart = _generalService.GetDateTimeStringForDatepicker(racer.DateTimeStart),
                RacerDateTimeEnd = racer.DateTimeEnd.HasValue
                    ? _generalService.GetDateTimeStringForDatepicker((DateTime)racer.DateTimeEnd)
                    : "-"
            };
            return model;
        }

        private IEnumerable<SelectListItem> getHorsesListForDropdown(IEnumerable<Horse> horses)
        {
            horses = horses.OrderBy(x => x.Nickname);
            var listHorses = horses.Select(horse =>
                                           new SelectListItem
                                           {
                                               Value = horse.Id.ToString(CultureInfo.InvariantCulture),
                                               Text = horse.Nickname
                                           });
            return listHorses;
        }

        private IEnumerable<SelectListItem> getJockeysListForDropdown(IEnumerable<Jockey> jockeys)
        {
            jockeys = jockeys.OrderBy(x => x.Alias);
            var listJockeys = jockeys.Select(jockey =>
                    new SelectListItem
                    {
                        Value = jockey.Id.ToString(CultureInfo.InvariantCulture),
                        Text = jockey.Alias + " (" + jockey.FullName + ")"
                    });
            return listJockeys;
        }
    }
}