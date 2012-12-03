using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
using KSS.HorseRacing.Infrastucture.DataModels;

namespace KSS.HorseRacing.Services
{
    using Infrastucture.DataAccess;
    using Models;

    public class RaceService
    {
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
                                RaceDateTime = race.DateTimeOfRace.ToShortDateString(),
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
                var dateTime = DateTime.Now;
                model.DateTimeOfRace = dateTime.Day + "-" + dateTime.Month + "-" + dateTime.Year;
                return model;
            }
        }

        private IEnumerable<SelectListItem> getPartisipantsListForDropdown(IEnumerable<Racer> racers)
        {
            if (racers == null) throw new ArgumentNullException("racers");
            var selectListItems = racers.Select(racer => new SelectListItem
                {
                    Value = racer.Id.ToString(CultureInfo.InvariantCulture),
                    Text = "∆окей " + racer.Jockey.Alias + " и лошадь " + racer.Horse.Nickname
                });
            return selectListItems;
        }
    }
}