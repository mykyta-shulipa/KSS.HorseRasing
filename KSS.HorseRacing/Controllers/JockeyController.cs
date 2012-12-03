namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Models;
    using KSS.HorseRacing.Services;

    [KssAuthorize]
    public class JockeyController : Controller
    {
        private readonly JokeyService _jokeyService;

        public JockeyController(JokeyService jokeyService)
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

        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Create()
        {
            return View(new JockeyViewModel());
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Create(JockeyViewModel model)
        {
            try
            {
                _jokeyService.AddNewJockey(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        [KssAuthorize(Roles = Role.ADMIN + "," + Role.JUDGE)]
        public ActionResult Edit(int id)
        {
            var model = _jokeyService.GetJockeyDetails(id);
            return View(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN + "," + Role.JUDGE)]
        public ActionResult Edit(JockeyViewModel model)
        {
            try
            {
                _jokeyService.EditJockey(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Delete(int id)
        {
            var model = _jokeyService.GetJockeyDetails(id);
            return View(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult DeleteJockey(int id)
        {
            try
            {
                _jokeyService.DeleteJockey(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
