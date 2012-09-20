namespace KSS.HorseRacing.Controllers
{
    using System;
    using System.Web.Mvc;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            new EfContext().Jockeys.Add(new Jockey{DateBirth = DateTime.Now});
            return View();
        }

    }
}
