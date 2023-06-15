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

        public override int Weight => 0;

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
            // Castling
            if (Color == Color.White && colDifference == 2 && rowDifference == 0 && destination.Row == 0)
            {
                // check rook is home
                // direction is -1 if KingSide, 1 if QueenSide
                int direction = destination.Col < Position.Col ? -1 : 1;
                int rookColumn = direction == -1 ? 0 : 7;
                Piece rook = board[0, rookColumn];
                if (rook == null) return false;
                if (rook.Value != 'R') return false;
                // check rook is in Line of Sight
                for (int i = Position.Col + direction; i != rookColumn; i += direction)
                {
                    if (board[Position.Row, i] != null) return false;
                }
                // King Must be in correct Column
                return Position.Col == 3;
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
                for (int i = Position.Col + direction; i != rookColumn; i += direction)
                {
                    if (board[Position.Row, i] != null) return false;
                }

                // King Must be in correct Column
                return  Position.Col == 3;
            }
            return false;
        }
    }
}
