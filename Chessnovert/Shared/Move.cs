using Chessnovert.Shared.Chess;
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
        public DateTime At { get; }

        public Move(Coordinate source, Coordinate destination)
        {
            Source = source;
            Destination = destination;
            At = DateTime.Now;
        }
    }
}
