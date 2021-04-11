using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LudoGame.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameStarted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GameEnded = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<int>(type: "INTEGER", nullable: false),
                    BoardID = table.Column<int>(type: "INTEGER", nullable: false),
                    AI = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Move",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerID = table.Column<int>(type: "INTEGER", nullable: false),
                    PieceID = table.Column<int>(type: "INTEGER", nullable: false),
                    DiceValue = table.Column<int>(type: "INTEGER", nullable: false),
                    BoardID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Move", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Move_Board_BoardID",
                        column: x => x.BoardID,
                        principalTable: "Board",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Move_BoardID",
                table: "Move",
                column: "BoardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Move");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Board");
        }
    }
}
