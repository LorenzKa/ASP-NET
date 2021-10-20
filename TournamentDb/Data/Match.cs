using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentDb
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
        [Range(1,5)]
        public int RoundNumber { get; set; }
        [Required]
        public Player Player1 { get; set; }
        [Required]
        public Player Player2 { get; set; }
        [Range(1,2)]
        public int? Winner { get; set; }
    }
}
