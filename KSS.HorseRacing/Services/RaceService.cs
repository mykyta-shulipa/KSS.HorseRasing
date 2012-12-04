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

    public class RaceService
    {
        private readonly GeneralService _generalService;

        public RaceService(GeneralService generalService)
        {
            _generalService = generalService;
        }

        public IEnumerable<RaceViewModel> GetListRaces()
        {
            using (var unit = new UnitOfWork())
            {
                var model = new List<RaceViewModel>();
                var allRaces = unit.Race.GetAllRaces();
                foreach (var race in allRaces)
                {
                    var loadParticipants = unit.Participant.LoadParticipants(
                        new ParticipantFilter
                        {
                            RaceId = race.Id,
                            WithJockey = true,
                            WithHorse = true
                        });
                    var participants = loadParticipants.Select(participant =>
                        new ParticipantViewModel
                        {
                            HorseId = participant.Racer.HorseId,
                            HorseNickname = participant.Racer.Horse.Nickname,
                            JockeyId = participant.Racer.JockeyId,
                            JockeyAlias = participant.Racer.Jockey.Alias,
                            ParticipantId = participant.Id,
                            NumberInRace = participant.NumberInRace,
                            PlaceInRace = participant.PlaceInRace
                        }).ToList();
                    model.Add(
                        new RaceViewModel
                            {
                                RaceId = race.Id,
                                RaceDateTime = _generalService.GetDateTimeStringForDatepicker(race.DateTimeOfRace),
                                RaceNumberInDay = race.NumberRaceInDay.ToString(CultureInfo.InvariantCulture),
                                Participants = participants
                            });
                }

                return model;
            }
        }

        public RaceCreateViewModel GetRaceCreateViewModel()
        {
            using (var unit = new UnitOfWork())
            {
                var model = new RaceCreateViewModel();
                var participants = unit.Racer.LoadRacers(
                    new RacerFilter
                        {
                            WithHorse = true,
                            WithJockey = true
                        });
                model.ListParticipantsForDropdown = getPartisipantsListForDropdown(participants);                
                model.DateTimeOfRace = DateTime.Now.ToShortDateString();
                return model;
            }
        }

        public void AddNewRace(RaceCreateViewModel model)
        {

            using (var unit = new UnitOfWork())
            {
                var race = new Race
                {
                    DateTimeOfRace = DateTime.Parse(model.DateTimeOfRace),
                    NumberRaceInDay = Convert.ToInt32(model.NumberRaceInDay)
                };
                unit.Race.Save(race);

                foreach (var viewModel in model.Participants)
                {
                    var racer = unit.Racer.Get(viewModel.RacerId);
                    var participant = new Participant
                    {
                        Race = race,
                        Racer = racer,
                        NumberInRace = viewModel.NumberInRace,
                        PlaceInRace = viewModel.PlaceInRace
                    };
                    unit.Participant.Save(participant);
                }
            }
        }

        private IEnumerable<SelectListItem> getPartisipantsListForDropdown(IEnumerable<Racer> racers)
        {
            if (racers == null)
            {
                throw new ArgumentNullException("racers");
            }

            var selectListItems = racers.Select(
                racer => new SelectListItem
                {
                    Value = racer.Id.ToString(CultureInfo.InvariantCulture),
                    Text = "∆окей " + racer.Jockey.Alias + " и лошадь " + racer.Horse.Nickname
                });
            return selectListItems;
        }
    }
}