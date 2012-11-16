namespace KSS.HorseRacing.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Security;

    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Models;
    using KSS.HorseRacing.Services;

    [KssAuthorize(Roles = Role.ADMIN)]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var lIst = _userService.GetUsersListModel();
            return View(lIst);
        }

        public ActionResult Edit(int id)
        {
            var model = _userService.GetUserEditModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserEditViewModel model)
        {
            try
            {
                var exist = _userService.CheckIfUserWithUsernameExist(model.Username);
                if (!exist)
                {
                    var editedUserUsernameOld = _userService.EditUser(model);
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
                return View(model);
            }

            return View(model);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            var model = _userService.GetUserDetailsModel(id);
            return View(model);
        }

        //
        // POST: /User/Delete/5

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
