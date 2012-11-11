namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    using KSS.HorseRacing.Services;

    [KssAuthorize]
    public class HorsesController : Controller
    {
        private readonly HorseService _horseService;

        public HorsesController(HorseService horseService)
        {
            _horseService = horseService;
        }

        public ActionResult Index()
        {
            var model = _horseService.GetListHorses();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Horses/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Horses/Create

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

        //
        // GET: /Horses/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Horses/Edit/5

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
        // GET: /Horses/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Horses/Delete/5

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
