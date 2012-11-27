namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    using KSS.HorseRacing.Services;

    [KssAuthorize]
    public class RaceController : Controller
    {
        private readonly RaceService _raceService;

        public RaceController(RaceService raceService)
        {
            _raceService = raceService;
        }

        public ActionResult Index()
        {
            var model = _raceService.GetListRaces();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            new RaceViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Race/Edit/5

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
        // GET: /Race/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Race/Delete/5

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

    public class RaceViewModel
    {        
    }
}
