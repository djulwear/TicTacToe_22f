
using GameBrain;

namespace ConsoleUI;

public static class UI
{
    public static void DrawGameBoard(EGamePiece?[][] board)
    {
        var cols = board.GetLength(0);
        var rows = board[0].GetLength(0);
        var line = board.GetLength(0);

        Console.WriteLine("   A   B   C");
        Console.Write(" ");
        for (int i = 0; i < rows; i++, line--)
        {
            //отрисовка горизонтальных линий
            for (int j = 0; j < cols; j++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");
            Console.Write(line);

            //заполнение блоков 
            for (int j = 0; j < cols; j++)
            {
                Console.Write("|");
                var pieceStr =
                    board[j][i] == null
                        ? "  "
                        : board[j][i] == EGamePiece.Black
                            ? " X"
                            : " O";

                Console.Write(pieceStr);
                Console.Write(" ");
            }

            Console.WriteLine("|");
            Console.Write(" ");
        }

        for (int j = 0; j < cols; j++)
        {
            Console.Write("+---");
        }

        Console.WriteLine("+");

        /*
            A   B   C
          +---+---+---+
        3 | X | O |   |
          +---+---+---+
        2 | O | X |   |
          +---+---+---+
        1 | O | X | O |
          +---+---+---+




         */
    }
}