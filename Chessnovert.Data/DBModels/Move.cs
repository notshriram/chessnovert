using System.ComponentModel.DataAnnotations;

namespace Chessnovert.Data.DBModels
{
    public class Move
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string? WhiteMove { get; set; }

        [Required]
        public DateTime WhiteTime { get; set; }

        [MaxLength(5)]
        public string? BlackMove { get; set; }

        public DateTime? BlackTime { get; set; }

        [Required]
        public int GameId { get; set; }

        public virtual Game? Game { get; set; }
    }
}
