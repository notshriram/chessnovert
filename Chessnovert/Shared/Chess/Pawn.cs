using Chessnovert.Shared.Chess.Enums;

namespace Chessnovert.Shared.Chess
{
    public class Pawn : Piece
    {
        public Pawn(Color color, Coordinate position) : base(color, position)
        {
        }

        public override char Value => 'P';

        public override string Name => "Pawn";

        public override bool CheckLegal(Coordinate destination, Piece[,] board)
        {
            Piece destinationPiece = board[destination.Row, destination.Col];
            if (destinationPiece == null)
            {
                if (destination.Col == Position.Col)
                {
                    if (Color == Color.White)
                    {
                        if (destination.Row == Position.Row + 1) return true;
                        // Double Step
                        if (board[Position.Row + 1, Position.Col] == null)
                            if ((destination.Row == Position.Row + 2) && (Position.Row == 1))
                                return true;

                    }
                    if (Color == Color.Black)
                    {
                        if (destination.Row == Position.Row - 1) return true;
                        // Double Step
                        if (board[Position.Row - 1, Position.Col] == null)
                            if ((destination.Row == Position.Row - 2) && (Position.Row == 6)) 
                                return true;
                    }
                }
                // en passant.
                // absdiff == 1 -> { en passant logic }
                else if (Math.Abs(destination.Col - Position.Col) == 1)
                {
                    // Opposite Coloured Pawn Stands Beside
                    if (board[Position.Row, destination.Col] != null 
                        && board[Position.Row, destination.Col].Value=='P' 
                        && board[Position.Row, destination.Col].Color != Color)
                    {
                        if (Color == Color.White && Position.Row == 4)
                        {
                            if (destination.Row == Position.Row + 1) return true;

                        }
                        if (Color == Color.Black && Position.Row == 3)
                        {
                            if (destination.Row == Position.Row - 1) return true;
                        }

                    }
                }
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
