using GameBrain;

namespace Domain;

public class TicTacToeGameState
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    //public EGamePiece?[,] GameBoard = default!;
    // serialize actual board array into json string
    public string SerializedGameState { get; set; } = default!;

    public int TicTacTOeGameId { get; set; }
    public TicTacToeGame? TicTacToeGame { get; set; }
}