namespace KSS.HorseRacing.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PasswordViewModel
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the compare password.
        /// </summary>
        /// <value>
        /// The compare password.
        /// </value>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Make sure passwords match")]
        public string ComparePassword { get; set; }
    }
}