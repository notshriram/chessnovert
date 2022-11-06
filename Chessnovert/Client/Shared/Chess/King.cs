using Chessnovert.Client.Shared.Chess.Enums;

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
            throw new NotImplementedException();
        }
    }
}
