using Chessnovert.Shared.Chess.Enums;

namespace Chessnovert.Shared.Chess
{
    public class Queen : Piece
    {
        public Queen(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'Q';

        public override string Name => "Queen";

        public override int Weight => 10;
        public override bool CheckLegal(Coordinate destination, Piece[,] board)
        {
            // Queen = Rook + Bishop

            // Rook Logic
            if (Position.Row == destination.Row)
            {
                int direction = destination.Col < Position.Col ? -1 : 1;
                for (int i = Position.Col + direction; i != destination.Col; i += direction)
                {
                    if (board[Position.Row, i] != null) return false;
                }
                return true;
            }

            else if (Position.Col == destination.Col)
            {
                int direction = destination.Row < Position.Row ? -1 : 1;
                for (var i = Position.Row + direction; i != destination.Row; i += direction)
                {
                    if (board[i, Position.Col] != null) return false;
                }
                return true;
            }

            // Bishop Logic
            int colDifference = Math.Abs(destination.Col - Position.Col);
            int rowDifference = Math.Abs(destination.Row - Position.Row);
            if (colDifference == rowDifference)
            {
                int rowDirection = destination.Row < Position.Row ? -1 : 1;
                int colDirection = destination.Col < Position.Col ? -1 : 1;
                for (int i = Position.Row + rowDirection, j = Position.Col + colDirection;
                    i != destination.Row && j != destination.Col;
                    i += rowDirection, j += colDirection)
                {
                    if (board[i, j] != null) return false;
                }
                return true;
            }

            return false;

        }
    }
}
