using Chessnovert.Shared.Chess.Enums;

namespace Chessnovert.Shared.Chess
{
    public class Knight : Piece
    {
        public Knight(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'N';

        public override string Name => "Knight";

        public override int Weight => 3;

        public override bool CheckLegal(Coordinate destination, Piece[,] Board)
        {
            if((Position.Row == destination.Row + 2) || (Position.Row == destination.Row - 2))
            {
                if((Position.Col == destination.Col + 1) || (Position.Col == destination.Col - 1))
                {
                    return true;
                }
            }
            if ((Position.Row == destination.Row + 1) || (Position.Row == destination.Row - 1))
            {
                if ((Position.Col == destination.Col + 2) || (Position.Col == destination.Col - 2))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
