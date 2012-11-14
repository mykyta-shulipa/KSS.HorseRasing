namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    using KSS.HorseRacing.Models;
    using KSS.HorseRacing.Services;

    [KssAuthorize]
    public class JokeyController : Controller
    {
        private readonly JokeyService _jokeyService;

        public JokeyController(JokeyService jokeyService)
        {
            _jokeyService = jokeyService;
        }

        public ActionResult Index()
        {
            var model = _jokeyService.GetListJokeys();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _jokeyService.GetJockeyDetails(id);
            return View(model);
        }

        public ActionResult Create()
        {            
            return View(new JockeyViewModel());
        }

        //
        // POST: /Jokey/Create

        [HttpPost]
        public ActionResult Create(JockeyViewModel model)
        {
            try
            {
                _jokeyService.AddNewJockey(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Jokey/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Jokey/Edit/5

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
        // GET: /Jokey/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Jokey/Delete/5

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
