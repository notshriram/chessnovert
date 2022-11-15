using Chessnovert.Shared.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chessnovert.Shared
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid PlayerWhite { get; set; }
        public Guid PlayerBlack { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public TimeSpan TimeControl { get; set; }
        public List<Move> Moves { get; set; } = new();

    }
}
