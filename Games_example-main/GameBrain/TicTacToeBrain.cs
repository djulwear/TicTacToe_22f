using Domain;

namespace GameBrain;

public class TicTacToeBrain
{
    private readonly TicTacToeState _state;

    public TicTacToeBrain(TicTacToeOption options)
    {
        var boardWidth = options.Width;
        var boardHeight = options.Height;

        if (boardWidth < 1 || boardHeight < 1)
        {
            throw new ArgumentException("Board size too small");
        }

        _state = new TicTacToeState();

        // Initialize the jagged array
        _state.GameBoard = new EGamePiece?[boardWidth][];
        for (int i = 0; i < boardWidth; i++)
        {
            _state.GameBoard[i] = new EGamePiece?[boardHeight];
        }

     
    }



    public EGamePiece?[][] GetBoard()
    {
        var jsonStr = System.Text.Json.JsonSerializer.Serialize(_state.GameBoard);
        return System.Text.Json.JsonSerializer.Deserialize<EGamePiece?[][]>(jsonStr)!;
    }
}