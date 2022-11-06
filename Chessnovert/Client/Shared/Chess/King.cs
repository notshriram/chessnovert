using Chessnovert.Client.Shared. Chess.Enums;

namespace Chessnovert.Client.Shared.Chess
{
    class King : Piece
    {
        public King(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'K';

        public override string Name => "King";

        public override bool CheckLegal(Coordinate destination, Piece[,] Board)
        {
            // Difference between Rows <= 1
            // And
            // Difference between Cols <= 1

            int rowDifference = Math.Abs(destination.Row - Position.Row);
            int colDifference = Math.Abs(destination.Col - Position.Col);
            if((rowDifference <= 1) && (colDifference <= 1))
            {
                return true;
            }
            //TODO: Add Castling
            return false;
        }
    }
}
