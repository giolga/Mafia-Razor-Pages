using System.ComponentModel.DataAnnotations;

namespace Mafia_Razor_Pages.Models
{
    public class GameAction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Character { get; set; }
        [Required]
        public int TargetSeatNumber { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
