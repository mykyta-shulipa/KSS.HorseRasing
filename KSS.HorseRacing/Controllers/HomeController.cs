using KSS.HorseRacing.Services;

namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly HorseService _horseService;
        private readonly RaceService _raceService;
        private readonly JokeyService _jokeyService;

        public HomeController(
            HorseService horseService, 
            RaceService raceService, 
            JokeyService jokeyService)
        {
            _horseService = horseService;
            _raceService = raceService;
            _jokeyService = jokeyService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Queries()
        {
            return View();
        }

        /*   public ActionResult SetCulture(string culture)
           {
               // Validate input
               culture = CultureHelper.GetValidCulture(culture);

               // Save culture in a cookie
               var cookie = Request.Cookies["_culture"];
               if (cookie != null)
               {
                   cookie.Value = culture; // update cookie value
               }
               else
               {

                   cookie = new HttpCookie("_culture")
                   {
                       HttpOnly = false, 
                       Value = culture, 
                       Expires = DateTime.Now.AddYears(1)
                   };
               }

               Response.Cookies.Add(cookie);

               return RedirectToAction("Index");
           }*/

        public ActionResult SelectHorseParticipation()
        {
            var model = _horseService.SelectHorseParticipation();
            return View(model);
        }

        public ActionResult SelectWinners()
        {
            const int quantityParticipants = 15;
            var winners = _raceService.SelectWinners(quantityParticipants);
            ViewBag.Quantity = quantityParticipants;
            return View(winners);
        }

        public ActionResult SelectWinnerJokeys()
        {
            return View();
        }

        public ActionResult GetWinnerJokeyForYear(int year)
        {
            var model = _jokeyService.GetWinnerJokeysForYear(year);
            return PartialView("PartialWinnerJockeysForYear", model);
        }
    }
}
