using System.ComponentModel.DataAnnotations;

namespace KSS.HorseRacing.Models
{
    public class HorseParticipationViewModel
    {
        public int HorseId { get; set; }

        [Display(Name = "Кличка лошади")]
        public string HorseNickname { get; set; }

        [Display(Name = "Количество заездов")]
        public int RaceQuantity { get; set; }
    }
}