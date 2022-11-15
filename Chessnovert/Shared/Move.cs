using Chessnovert.Shared.Chess;
using Chessnovert.Shared.Chess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnovert.Shared
{
    public class Move
    {
        public Coordinate Source { get; }
        public Coordinate Destination { get; }
        public Color Color { get; }
        public DateTime At { get; }

        public Move(Coordinate source, Coordinate destination, Color color)
        {
            Source = source;
            Destination = destination;
            Color = color;
            At = DateTime.Now;
        }
    }
}
