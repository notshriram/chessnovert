namespace Chessnovert.Models
{
    public enum ResultEnum
    {
        WhiteVictory = 0,
        BlackVictory,
        DrawByAgreement,
        DrawByStalemate,
        DrawByRepetition,
        DrawByFiftyMoveRule,
        DrawByInsufficientMaterial,
        Abandoned,
        Aborted
    }
}
