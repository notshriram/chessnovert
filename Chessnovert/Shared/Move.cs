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
        public Piece? Displaced { get; set; }
        public bool IsCastling { get; set; } = false;
        public bool IsEnPassant { get; set; } = false;
        public Piece? Promoted { get; set; }
        public Color Color { get; }
        public DateTime At { get; }
        public int Score { get; set; } = 0;
        public Move(Coordinate source, Coordinate destination, Color color)
        {
            Source = source;
            Destination = destination;
            Color = color;
            At = DateTime.Now;
        }
        public Move(Coordinate source, Coordinate destination, Color color, Piece? displaced)
        {
            Source = source;
            Destination = destination;
            Color = color;
            At = DateTime.Now;
            Displaced = displaced;
        }
        public Move(Coordinate source, Coordinate destination, Color color, Piece? displaced, bool isCastling)
        {
            Source = source;
            Destination = destination;
            Color = color;
            At = DateTime.Now;
            Displaced = displaced;
            IsCastling = isCastling;
        }
        public Move(Coordinate source, Coordinate destination, Color color, Piece? displaced, Piece? promoted)
        {
            Source = source;
            Destination = destination;
            Color = color;
            Displaced = displaced;
            At = DateTime.Now;
            Promoted = promoted;
        }
    }
}
