using Chessnovert.Client.Shared.Chess.Enums;

namespace Chessnovert.Client.Shared.Chess
{
    abstract class Piece
    {
        public Piece(Color color)
        {
            Color = color;
        }
        public abstract char Value { get; }
        public Color Color { get; }

        public abstract int Row { get; set; }
        public abstract int Col { get; set; }

        // Dest Row + Dest Col => New Coordinate Struct?
        public bool IsLegal(int destinationRow, int destinationCol, Piece[][] Board)
        {
            Piece piece = Board[destinationRow][destinationCol];
            if ((piece==null) || (this.Color!=piece.Color))
            {
                return CheckLegal(destinationRow, destinationCol, Board);
            }
            return false;
        }
        public abstract bool CheckLegal(int destinationRow, int destinationCol, Piece[][] Board);
        
    }
}
