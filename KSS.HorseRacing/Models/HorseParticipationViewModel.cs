using System.ComponentModel.DataAnnotations;

namespace KSS.HorseRacing.Models
{
    public class HorseParticipationViewModel
    {
        public int HorseId { get; set; }

        [Display(Name = "������ ������")]
        public string HorseNickname { get; set; }

        [Display(Name = "���������� �������")]
        public int RaceQuantity { get; set; }
    }
}