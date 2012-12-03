using System;

namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Models;
    using KSS.HorseRacing.Services;

    [KssAuthorize]
    public class RacerController : Controller
    {
        private readonly RacerService _racerService;

        public RacerController(RacerService racerService)
        {
            _racerService = racerService;
        }

        public ActionResult Index()
        {
            var racers = _racerService.GetListRacers();
            return View(racers);
        }

        public ActionResult Details(int id)
        {
            var model = _racerService.GetRacerDetails(id);
            return View(model);
        }

        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Create()
        {
            var model = _racerService.GetRacerCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Create(RacerCreateViewModel model)
        {
            try
            {
                _racerService.AddNewRacer(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Racer");
            }

            var model = _racerService.GetRacerEditModel(id);
            return View(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Edit(RacerEditViewModel model)
        {
            try
            {
                _racerService.EditRacer(model);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Что-то пошло не так. Попробуйте ещё раз!");
                return View(model);
            }
        }

        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
            return View();
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN)]
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
