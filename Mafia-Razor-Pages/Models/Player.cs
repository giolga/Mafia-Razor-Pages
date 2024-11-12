using System.ComponentModel.DataAnnotations;

namespace Mafia_Razor_Pages.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public byte? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gmail { get; set; }
    }
}
