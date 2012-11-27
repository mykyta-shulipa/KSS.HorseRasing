namespace KSS.HorseRacing.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateUserViewModel
    {
        public IEnumerable<SelectListItem> RolesForDropdown { get; set; }

        [Display(Name = "�������� ����:")]
        public int SelectedRole { get; set; }

        [Display(Name = "��� ������������ (�����)")]
        public string Username { get; set; }
    }
}