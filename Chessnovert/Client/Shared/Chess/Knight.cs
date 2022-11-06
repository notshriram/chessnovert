using Chessnovert.Client.Shared.Chess.Enums;

namespace Chessnovert.Client.Shared.Chess
{
    class Knight : Piece
    {
        public Knight(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'N';

        public override string Name => "Knight";

        public override bool CheckLegal(Coordinate destination, Piece[,] Board)
        {
            throw new NotImplementedException();
        }
    }
}
