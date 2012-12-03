namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;

    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Models;
    using KSS.HorseRacing.Services;

    [KssAuthorize(Roles = Role.ADMIN)]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        private readonly SessionStorage _sessionStorage;

        public UserController(UserService userService, SessionStorage sessionStorage)
        {
            _userService = userService;
            _sessionStorage = sessionStorage;
        }

        public ActionResult Settings()
        {
            var model = _userService.GetSettingsViewModel();
            var value = _sessionStorage.GetValueAndClearAfter(SessionStorage.SETTINGS_MESSAGE_KEY);
            if (!string.IsNullOrWhiteSpace(value))
            {
                model.MessageToShowAbove = value;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(SettingsViewModel model)
        {
            _userService.ChangePassword(model.UserId, model.PasswordModel.Password);
            _sessionStorage.AddValueWithKey(SessionStorage.SETTINGS_MESSAGE_KEY, "Your password has been changed.");
            return RedirectToAction("Settings");
        }
    }
}
