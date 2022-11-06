using Chessnovert.Client.Shared.Chess.Enums;

namespace Chessnovert.Client.Shared.Chess
{
    class Queen : Piece
    {
        public Queen(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'Q';

        public override string Name => "Queen";

        public override bool CheckLegal(Coordinate destination, Piece[][] Board)
        {
            throw new NotImplementedException();
        }
    }
}
