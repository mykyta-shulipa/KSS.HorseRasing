namespace KSS.HorseRacing.Controllers
{
    using System;
    using System.Web.Mvc;

    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Models;
    using KSS.HorseRacing.Services;

    [KssAuthorize]
    public class RaceController : Controller
    {
        private readonly RaceService _raceService;

        private readonly RacerService _racerService;

        public RaceController(RaceService raceService, RacerService racerService)
        {
            _raceService = raceService;
            _racerService = racerService;
        }

        public ActionResult Index()
        {
            var model = _raceService.GetListRaces();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
            return View();
        }

        [KssAuthorize(Roles = Role.JUDGE)]
        public ActionResult Create()
        {
            var model = _raceService.GetRaceCreateViewModel();
            return View(model);
        }
        
        [HttpPost]        
        public ActionResult GetParticipantInfo(int participantId)
        {
            var model = _racerService.GetRacerViewModel(participantId);
            return Json(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.JUDGE)]
        public ActionResult Create(RaceCreateViewModel model)
        {            
            try
            {
                _raceService.AddNewRace(model);                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Race/Edit/5

        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
            return View();
        }

        //
        // POST: /Race/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            throw new NotImplementedException();
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Race/Delete/5

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
            return View();
        }

        //
        // POST: /Race/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            throw new NotImplementedException();
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
