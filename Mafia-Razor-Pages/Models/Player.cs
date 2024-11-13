using System.ComponentModel.DataAnnotations;

namespace Mafia_Razor_Pages.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required!")]
        public string Surname { get; set; }
        public byte? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gmail { get; set; }
        // added later! Seat number on the table
        public byte SeatNumber { get; set; }
    }
}
