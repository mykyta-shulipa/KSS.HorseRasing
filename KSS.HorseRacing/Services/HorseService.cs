namespace KSS.HorseRacing.Services
{
    using System;
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Models;
    
    public class HorseService
    {
        private readonly GeneralService _generalService;

        public HorseService(GeneralService generalService)
        {
            _generalService = generalService;
        }

        public IList<Horse> GetListHorses()
        {
            using (var unit = new UnitOfWork())
            {
                var horses = unit.Horse.GetAllHorses();
                return horses;
            }
        }

        public HorseViewModel GetHorseDetails(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var horse = unit.Horse.Get(id);
                var model = new HorseViewModel
                {
                    HorseId = horse.Id,
                    DateBirth = _generalService.GetDateTimeStringForDatepicker(horse.DateBirth),
                    Nickname = horse.Nickname
                };
                return model;
            }
        }

        public void AddNewHorse(HorseViewModel model)
        {
            using (var unit = new UnitOfWork())
            {
                var horse = new Horse
                {
                    Nickname = model.Nickname,
                    DateBirth = DateTime.Parse(model.DateBirth)
                };
                unit.Horse.Save(horse);
            }
        }

        public void EditHorse(HorseViewModel model)
        {
            using (var unit = new UnitOfWork())
            {
                var horse = unit.Horse.Get(model.HorseId);
                horse.Nickname = model.Nickname;
                horse.DateBirth = DateTime.Parse(model.DateBirth);
                unit.Horse.Save(horse);
            }
        }

        public void DeleteHorse(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var horse = unit.Horse.Get(id);
                unit.Horse.Delete(horse);
            }
        }
    }
}