using Chessnovert.Client.Shared.Chess.Enums;

namespace Chessnovert.Client.Shared.Chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'B';

        public override string Name => "Bishop";

        public override bool CheckLegal(Coordinate destination, Piece[,] board)
        {
            // Diagon Alley
            // The difference between rows should be equal to the difference between columns

            int colDifference = Math.Abs(destination.Col - Position.Col);
            int rowDifference = Math.Abs(destination.Row - Position.Row);
            if(colDifference == rowDifference)
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
