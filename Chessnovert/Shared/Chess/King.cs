using Chessnovert.Shared.Chess.Enums;

namespace Chessnovert.Shared.Chess
{
    public class King : Piece
    {
        public King(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'K';

        public override string Name => "King";

        public override bool CheckLegal(Coordinate destination, Piece[,] board)
        {
            // Difference between Rows <= 1
            // And
            // Difference between Cols <= 1

            int rowDifference = Math.Abs(destination.Row - Position.Row);
            int colDifference = Math.Abs(destination.Col - Position.Col);
            if ((rowDifference <= 1) && (colDifference <= 1))
            {
                return true;
            }
            //TODO: Add Castling
            if (Color == Color.White && colDifference == 2 && rowDifference == 0 && destination.Row == 0)
            {
                // check rook is home
                int direction = destination.Col < Position.Col ? -1 : 1;
                int rookColumn = direction == -1 ? 0 : 7;
                Piece rook = board[0, rookColumn];
                if (rook == null) return false;
                if (rook.Value != 'R') return false;
                // check rook is in Line of Sight
                for (int i = Position.Col + direction; i != destination.Col; i += direction)
                {
                    if (board[Position.Row, i] != null) return false;
                }
                return true;
            }
            else if (Color == Color.Black && colDifference == 2 && rowDifference == 0 && destination.Row == 7)
            {
                // if rook is in Line of Sight
                // check rook is home
                int direction = destination.Col < Position.Col ? -1 : 1;
                int rookColumn = direction == -1 ? 0 : 7;
                Piece rook = board[7, rookColumn];
                if (rook == null) return false;
                if (rook.Value != 'R') return false;
                // check rook is in Line of Sight
                for (int i = Position.Col + direction; i != destination.Col; i += direction)
                {
                    if (board[Position.Row, i] != null) return false;
                }
                return true;
            }
            return false;
        }
    }
}
