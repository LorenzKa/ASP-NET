using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentDb
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
