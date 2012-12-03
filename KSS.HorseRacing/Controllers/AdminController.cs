using KSS.HorseRacing.Infrastucture.DataModels;

namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;

    using Models;
    using Services;

    [KssAuthorize(Roles = Role.ADMIN)]
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult Index()
        {
            var list = _adminService.GetUsersListModel();
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            var model = _adminService.GetUserEditModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserEditViewModel model)
        {
            try
            {
                var exist = _adminService.CheckIfUserWithUsernameExist(model.Username);
                if (!exist)
                {
                    var editedUserUsernameOld = _adminService.EditUser(model);
                    if (string.Equals(User.Identity.Name, editedUserUsernameOld) && !string.Equals(model.Username, editedUserUsernameOld))
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.SetAuthCookie(editedUserUsernameOld, false);
                    }

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Что-то пошло не так. Попробуйте ещё раз!");
                return View(model);
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = _adminService.GetUserDetailsModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _adminService.DeleteUser(id);

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Что-то пошло не так. Попробуйте ещё раз!");
                return RedirectToAction("Delete", "Admin", new { id });
            }
        }

        public ActionResult Create()
        {
            var model = _adminService.GetCreateUserViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateUserViewModel model)
        {
            try
            {
                _adminService.CreateUser(model);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Что-то пошло не так. Попробуйте ещё раз!");
                return View(model);
            }
        }

    }
}
