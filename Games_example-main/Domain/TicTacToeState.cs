using GameBrain;

namespace Domain;

public class TicTacToeState
{
    public EGamePiece?[][] GameBoard = default!;
    public bool NextMoveByBlack { get; set; }
}
