using Chessnovert.Client.Shared.Chess.Enums;

namespace Chessnovert.Client.Shared.Chess
{
    class Rook : Piece
    {
        public Rook(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'R';

        public override string Name => "Rook";

        public override bool CheckLegal(Coordinate destination, Piece[,] Board)
        {
            throw new NotImplementedException();
        }
    }
}
