using Chessnovert.Client.Shared.Chess.Enums;

namespace Chessnovert.Client.Shared.Chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, Coordinate position) : base(color,position)
        {
        }

        public override char Value => 'P';

        public override string Name => "Pawn";

        public override bool CheckLegal(Coordinate destination, Piece[][] Board)
        {
            throw new NotImplementedException();
        }
    }
}
