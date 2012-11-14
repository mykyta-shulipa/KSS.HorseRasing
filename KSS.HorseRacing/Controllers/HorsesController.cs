namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Models;
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
            var model = _horseService.GetHorseDetails(id);
            return View(model);
        }

        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Create()
        {
            return View(new HorseViewModel());
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult Create(HorseViewModel model)
        {
            try
            {
                _horseService.AddNewHorse(model);
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
            var model = _horseService.GetHorseDetails(id);
            return View(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN + "," + Role.JUDGE)]
        public ActionResult Edit(HorseViewModel model)
        {
            try
            {
                _horseService.EditHorse(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        [KssAuthorize(Roles = Role.ADMIN)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _horseService.GetHorseDetails(id);
            return View(model);
        }

        [HttpPost]
        [KssAuthorize(Roles = Role.ADMIN)]
        public ActionResult DeleteHorse(int id)
        {
            try
            {
                _horseService.DeleteHorse(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
