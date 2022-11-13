using Chessnovert.Shared.Chess.Enums;

namespace Chessnovert.Shared.Chess
{
    public class Rook : Piece
    {
        public Rook(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'R';

        public override string Name => "Rook";

        public override bool CheckLegal(Coordinate destination, Piece[,] board)
        {
            if (Position.Row == destination.Row)
            {
                int direction = destination.Col < Position.Col ? -1 : 1;
                for(int i = Position.Col+direction; i != destination.Col; i += direction)
                {
                    if (board[Position.Row, i] != null) return false;
                }
                return true;
            }

            else if (Position.Col == destination.Col)
            {
                int direction = destination.Row < Position.Row  ? -1 : 1;
                for(var i = Position.Row+direction; i != destination.Row; i += direction)
                {
                    if (board[i, Position.Col] != null) return false;
                }
                return true;
            }
            return false;
        }
    }
}
