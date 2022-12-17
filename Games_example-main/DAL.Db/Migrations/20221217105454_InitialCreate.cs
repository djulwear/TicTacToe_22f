using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Db.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicTacToeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    RandomMoves = table.Column<int>(type: "INTEGER", nullable: false),
                    WhiteStarts = table.Column<bool>(type: "INTEGER", nullable: false),
                    AI = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicTacToeOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicTacToeGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GameOverAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GameWonByPlayer = table.Column<string>(type: "TEXT", nullable: true),
                    Player1Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Player1Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Player2Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Player2Type = table.Column<int>(type: "INTEGER", nullable: false),
                    TicTacToeOptionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicTacToeGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicTacToeGames_TicTacToeOptions_TicTacToeOptionId",
                        column: x => x.TicTacToeOptionId,
                        principalTable: "TicTacToeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicTacToeGameStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SerializedGameState = table.Column<string>(type: "TEXT", nullable: false),
                    TicTacTOeGameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicTacToeGameStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicTacToeGameStates_TicTacToeGames_TicTacTOeGameId",
                        column: x => x.TicTacTOeGameId,
                        principalTable: "TicTacToeGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicTacToeGames_TicTacToeOptionId",
                table: "TicTacToeGames",
                column: "TicTacToeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicTacToeGameStates_TicTacTOeGameId",
                table: "TicTacToeGameStates",
                column: "TicTacTOeGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicTacToeGameStates");

            migrationBuilder.DropTable(
                name: "TicTacToeGames");

            migrationBuilder.DropTable(
                name: "TicTacToeOptions");
        }
    }
}
