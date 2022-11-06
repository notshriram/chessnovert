using Chessnovert.Client.Shared.Chess.Enums;

namespace Chessnovert.Client.Shared.Chess
{
    abstract class Piece
    {
        public Piece(Color color, Coordinate position)
        {
            Color = color;
            Position = position;
        }
        public abstract char Value { get; }

        public abstract string Name { get; }
        public Color Color { get; }

        public Coordinate Position { get; set; }
        // Dest Row + Dest Col => New Coordinate Struct?
        public bool IsLegal(Coordinate destination, Piece[,] Board)
        {
            Piece piece = Board[destination.Row,destination.Col];
            if ((piece==null) || (this.Color!=piece.Color))
            {
                return CheckLegal(destination, Board);
            }
            return false;
        }
        public abstract bool CheckLegal(Coordinate destination, Piece[,] Board);
        
    }
}
