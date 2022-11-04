using Chessnovert.Models;
using System.ComponentModel.DataAnnotations;

namespace Chessnovert.Data.DBModels
{
    public class Game
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string? PlayerWhite { get; set; }

        [Required]
        public string? PlayerBlack { get; set; }

        public ResultEnum? Result { get; set; }

        [Required]
        public DateTime SessionStart { get; set; }

        public DateTime? SessionEnd { get; set; }

        public virtual ICollection<Move> Moves { get; set; } = new List<Move>();
    }
}
