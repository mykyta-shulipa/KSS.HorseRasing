namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateUserViewModel
    {
        public IEnumerable<SelectListItem> RolesForDropdown { get; set; }

        [Display(Name = "Select role:")]
        public int SelectedRole { get; set; }

        public string Username { get; set; }
    }
}