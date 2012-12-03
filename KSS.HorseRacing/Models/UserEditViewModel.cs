namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class UserEditViewModel
    {
        
        public int UserId { get; set; }

        public string Username { get; set; }

        public int SelectedRoleId { get; set; }

        public List<SelectListItem> Roles { get; set; }
    }
}