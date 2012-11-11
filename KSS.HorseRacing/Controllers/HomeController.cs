namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataAccess.Filters;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var unit = new UnitOfWork())
            {
                unit.User.LoadUsers(new UserFilter());
            }

            return View();
        }

    }
}
