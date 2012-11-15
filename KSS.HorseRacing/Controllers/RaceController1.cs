namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    using KSS.HorseRacing.Services;

    [KssAuthorize]
    public class RaceController1 : Controller
    {
        private RaceService _raceService;

        public RaceController1(RaceService raceService)
        {
            _raceService = raceService;
        }

        public ActionResult Index()
        {
            var model = _raceService.GetListRaces();
            return View(model);
        }

        public ActionResult Create()
        {
            throw new System.NotImplementedException();
        }
    }
}