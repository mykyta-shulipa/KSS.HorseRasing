namespace KSS.HorseRacing.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PasswordViewModel
    {
        private const string MESSAGE = "Поле обязательно к заполнению";

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required(ErrorMessage = MESSAGE)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the compare password.
        /// </summary>
        /// <value>
        /// The compare password.
        /// </value>
        [Required(ErrorMessage = MESSAGE)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        //[Compare("Password", ErrorMessage = "Make sure passwords match")]
        [Compare("Password", ErrorMessage = "Убедитесь в совпадении пароля")]
        public string ComparePassword { get; set; }
    }
}