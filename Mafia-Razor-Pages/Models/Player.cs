﻿using System.ComponentModel.DataAnnotations;

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
        public byte SeatNumber { get; set; } = 0;
        public string? Character { get; set; } = null;
        public bool IsFirstLose { get; set; } = false;
        public int NumberOfFouls { get; set; } = 0;
        public bool Lose { get; set; }
    }
}
