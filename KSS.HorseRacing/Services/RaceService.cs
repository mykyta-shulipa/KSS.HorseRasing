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

                    var participants = getParticipantsViewModelsList(unit, race.Id);
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
            return GetRaceCreateViewModel(DateTime.Now);
        }

        public RaceCreateViewModel GetRaceCreateViewModel(DateTime dateTime, string numberInDay = null)
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
                model.DateTimeOfRace = dateTime.ToString("MM-dd-yyyy");
                if (!string.IsNullOrWhiteSpace(numberInDay))
                {
                    model.NumberRaceInDay = numberInDay;
                }

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

        public RaceDetailsViewModel GetRaceDetailsViewModel(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var race = unit.Race.Get(id);
                var model = getRaceDetailsViewModelWithoutParticipants(race);
                model.Participants = new List<ParticipantViewModel>();
                var participants = unit.Participant.LoadParticipants(new ParticipantFilter { RaceId = race.Id, WithRacerHorceAndJockey = true });
                foreach (var participant in participants)
                {
                    model.Participants.Add(new ParticipantViewModel
                    {
                        HorseId = participant.Racer.Horse.Id,
                        HorseNickname = participant.Racer.Horse.Nickname,
                        ParticipantId = participant.Id,
                        RacerId = participant.Racer.Id,
                        JockeyId = participant.Racer.Jockey.Id,
                        JockeyAlias = participant.Racer.Jockey.Alias,
                        NumberInRace = participant.NumberInRace,
                        PlaceInRace = participant.PlaceInRace
                    });
                }

                return model;
            }
        }

        private RaceDetailsViewModel getRaceDetailsViewModelWithoutParticipants(Race race)
        {
            var model = new RaceDetailsViewModel
            {
                RaceId = race.Id,
                DateTimeOfRace = race.DateTimeOfRace.ToShortDateString(),
                NumberRaceInDay = race.NumberRaceInDay.ToString(CultureInfo.InvariantCulture)
            };
            return model;
        }

        public void EditRace(RaceDetailsViewModel model)
        {
            using (var unit = new UnitOfWork())
            {
                var loadParticipants = unit.Participant.LoadParticipants(new ParticipantFilter { RaceId = model.RaceId });
                foreach (var participantViewModel in model.Participants)
                {
                    var viewModel = participantViewModel;
                    foreach (var participant in loadParticipants.Where(participant => viewModel.ParticipantId == participant.Id))
                    {
                        participant.NumberInRace = participantViewModel.NumberInRace;
                        participant.PlaceInRace = participantViewModel.PlaceInRace;
                        unit.Participant.Save(participant);
                        break;
                    }
                }
            }
        }

        public void DeleteRace(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var race = unit.Race.Get(id);
                var loadParticipants = unit.Participant.LoadParticipants(new ParticipantFilter { RaceId = race.Id });
                foreach (var participant in loadParticipants)
                {
                    unit.Participant.Delete(participant);
                }

                unit.Race.Delete(race);
            }
        }

        public List<WinnersViewModel> SelectWinners(int quantityParticipants)
        {
            using (var unit = new UnitOfWork())
            {
                var participants = unit.Participant.LoadParticipants(new ParticipantFilter { WithHorse = true, WithJockey = true });

                var models = new List<WinnersViewModel>();
                foreach (var participant in participants)
                {
                    var countWinnerRaces = unit.Participant.GetCountWinnerRaces(participant.Id);
                    if (countWinnerRaces > 0)
                    {
                        models.Add(new WinnersViewModel
                        {
                            HorseNickname = participant.Racer.Horse.Nickname,
                            JockeyAlias = participant.Racer.Jockey.Alias,
                            CountWinnerRaces = countWinnerRaces
                        });
                    }
                }

                var list = models.OrderByDescending(x => x.CountWinnerRaces).Take(quantityParticipants).ToList();
                return list;
            }
        }

        public List<ParticipantViewModel> GetParticipantsForRace(DateTime raceDate, int raceNumber)
        {
            using (var unit = new UnitOfWork())
            {
                var race = unit.Race.GetRace(raceDate, raceNumber);
                if (race == null)
                {
                    return null;
                }

                var list = getParticipantsViewModelsList(unit, race.Id);
                return list;
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

        private List<ParticipantViewModel> getParticipantsViewModelsList(UnitOfWork unit, int id)
        {
            var loadParticipants = unit.Participant.LoadParticipants(
                new ParticipantFilter
                {
                    RaceId = id,
                    WithJockey = true,
                    WithHorse = true
                });
            return loadParticipants.Select(participant =>
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
        }

        public List<RaceDetailsViewModel> GetRaces(DateTime date)
        {
            using (var unit = new UnitOfWork())
            {
                var races = unit.Race.GetRacesListForMonth(date);
                return races.Select(getRaceDetailsViewModelWithoutParticipants).ToList();
            }
        }
    }
}