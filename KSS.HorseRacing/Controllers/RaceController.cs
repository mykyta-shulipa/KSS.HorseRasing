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
            var model = _raceService.GetRaceDetailsViewModel(id);
            return View(model);
        }

        [KssAuthorize(Roles = Role.JUDGE)]
        public ActionResult Create()
        {
            var model = _raceService.GetRaceCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.JUDGE)]
        public ActionResult Create(RaceCreateViewModel model)
        {
            if (model.Participants == null)
            {
                ModelState.AddModelError(string.Empty, "Заезд должен иметь участников!");
                model = _raceService.GetRaceCreateViewModel(DateTime.Parse(model.DateTimeOfRace), model.NumberRaceInDay);
                return View(model);
            }

            _raceService.AddNewRace(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetParticipantInfo(int participantId)
        {
            var model = _racerService.GetRacerViewModel(participantId);
            return Json(model);
        }

        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Edit(int id)
        {
            var model = _raceService.GetRaceDetailsViewModel(id);
            return View(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Edit(RaceDetailsViewModel model)
        {
            _raceService.EditRace(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Delete(int id)
        {
            var model = _raceService.GetRaceDetailsViewModel(id);
            return View(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult DeleteRace(RaceDetailsViewModel model)
        {
            _raceService.DeleteRace(model.RaceId);
            return RedirectToAction("Index");
        }
    }
}
