namespace Domain;

public class TicTacToeOption
{ 
    // PK in db
    // PK = Primary key
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public int Width { get; set; } = 3; 
    public int Height { get; set; } = 3;
    public int RandomMoves { get; set; } = 0;
    public bool WhiteStarts { get; set; } = true;

    public enum AIlevel {Level1,Level2,Level3 };
    public AIlevel AI { get; set; } = AIlevel.Level1;

    // ICollection - no foo[]
    public ICollection<TicTacToeGame>? TicTacToeGames { get; set; }

    public override string ToString()
    {
        return $"Board: {Width}x{Height} " +
            $"Random: {RandomMoves} " +
            $"WhiteStarts:{WhiteStarts} " +
            $"AI lvl enum: {AI} ";
    }
}