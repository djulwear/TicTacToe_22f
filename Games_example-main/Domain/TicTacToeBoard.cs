using System;
namespace Domain
{
	public class TicTacToeBoard
	{
        // PK in db
        // PK = Primary key
        public string TiTacToeOptionsId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string BoardA1 { get; set; } = default!;
        public string BoardA2 { get; set; } = default!;
        public string BoardA3 { get; set; } = default!;
        public string BoardB1 { get; set; } = default!;
        public string BoardB2 { get; set; } = default!;
        public string BoardB3 { get; set; } = default!;
        public string BoardC1 { get; set; } = default!;
        public string BoardC2 { get; set; } = default!;
        public string BoardC3 { get; set; } = default!;

        // ICollection - no foo[]
        public ICollection<TicTacToeGame>? TicTacToeGames { get; set; }

        public override string ToString()
        {
            return $"Board Option: {TiTacToeOptionsId} " +
                $"Row 1: {BoardA1} + {BoardA2} + {BoardA3} " +
                $"Row 2: {BoardB1} + {BoardB2} + {BoardB3} " +
                $"Row 3: {BoardC1} + {BoardC2} + {BoardC3} ";
        }

    
	}
}

