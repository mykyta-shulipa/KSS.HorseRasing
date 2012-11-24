namespace KSS.HorseRacing.Models
{
    public class SettingsViewModel
    {
        public int UserId { get; set; }
        
        public PasswordViewModel PasswordModel { get; set; }
        
        public string MessageToShowAbove { get; set; }
    }
}