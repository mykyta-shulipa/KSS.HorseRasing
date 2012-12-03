namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateUserViewModel
    {
        public IEnumerable<SelectListItem> RolesForDropdown { get; set; }

        [Display(Name = "Выберите роль:")]
        public int SelectedRole { get; set; }

        [Display(Name = "Имя пользователя (логин)")]
        public string Username { get; set; }
    }
}