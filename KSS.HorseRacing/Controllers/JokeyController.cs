namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

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

        //
        // GET: /Jokey/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Jokey/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Jokey/Create

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
