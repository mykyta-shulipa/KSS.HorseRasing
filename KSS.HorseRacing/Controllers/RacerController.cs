namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    using KSS.HorseRacing.Models;
    using KSS.HorseRacing.Services;

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

        public ActionResult Create()
        {
            var model = _racerService.GetRacerCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RacerCreateViewModel model)
        {
            try
            {
                _racerService.AddNewRacer(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Racer/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Racer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
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
        // GET: /Racer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Racer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
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
