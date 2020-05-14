using Microsoft.EntityFrameworkCore.Migrations;

namespace RPS_Game.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    playerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    winAccess = table.Column<int>(nullable: false),
                    nameAccess = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.playerID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Player1playerID = table.Column<int>(nullable: true),
                    Player2playerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Players_Player1playerID",
                        column: x => x.Player1playerID,
                        principalTable: "Players",
                        principalColumn: "playerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_Player2playerID",
                        column: x => x.Player2playerID,
                        principalTable: "Players",
                        principalColumn: "playerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    roundID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    p1Choice = table.Column<string>(nullable: true),
                    p2Choice = table.Column<string>(nullable: true),
                    WinnerplayerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.roundID);
                    table.ForeignKey(
                        name: "FK_Rounds_Players_WinnerplayerID",
                        column: x => x.WinnerplayerID,
                        principalTable: "Players",
                        principalColumn: "playerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player1playerID",
                table: "Games",
                column: "Player1playerID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player2playerID",
                table: "Games",
                column: "Player2playerID");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_WinnerplayerID",
                table: "Rounds",
                column: "WinnerplayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
