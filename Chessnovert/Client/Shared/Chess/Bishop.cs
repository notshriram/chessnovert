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

        public override bool CheckLegal(Coordinate destination, Piece[,] Board)
        {
            throw new NotImplementedException();
        }
    }
}
