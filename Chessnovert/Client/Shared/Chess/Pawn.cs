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

        public override bool CheckLegal(Coordinate destination, Piece[,] board)
        {
            Piece destinationPiece = board[destination.Row, destination.Col];
            if(destinationPiece == null)
            {
                if(destination.Col == Position.Col)
                {
                    if(Color == Color.White)
                    {
                        if(destination.Row == Position.Row + 1) return true;
                        if((destination.Row == Position.Row + 2) && (Position.Row == 1))return true;
                    }
                    if(Color == Color.Black) 
                    {
                        if(destination.Row == Position.Row - 1) return true;
                        if((destination.Row == Position.Row - 2) && (Position.Row == 6))return true;
                    }
                }
                //TODO: en passant
            }
            else
            {
                if ((destination.Col == Position.Col + 1) || (destination.Col == Position.Col - 1))
                {
                    if (Color == Color.White)
                    {
                        if (destination.Row == Position.Row + 1) return true;
                    }
                    if (Color == Color.Black)
                    {
                        if (destination.Row == Position.Row - 1) return true;
                    }
                }

            }
            return false;

        }
    }
}
