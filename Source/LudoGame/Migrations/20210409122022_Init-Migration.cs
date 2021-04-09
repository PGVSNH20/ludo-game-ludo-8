using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LudoGame.Migrations
{
    public partial class InitMigration : Migration
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
                    Color = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Move",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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

            migrationBuilder.CreateTable(
                name: "Piece",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<int>(type: "INTEGER", nullable: false),
                    Moves = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentPositionID = table.Column<int>(type: "INTEGER", nullable: true),
                    StartPositionID = table.Column<int>(type: "INTEGER", nullable: true),
                    SixthPositionID = table.Column<int>(type: "INTEGER", nullable: true),
                    NestPositionID = table.Column<int>(type: "INTEGER", nullable: true),
                    EnterFinalTrackPositionID = table.Column<int>(type: "INTEGER", nullable: true),
                    MoveDirectionX = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveDirectionY = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piece", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Piece_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Position_CurrentPositionID",
                        column: x => x.CurrentPositionID,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Position_EnterFinalTrackPositionID",
                        column: x => x.EnterFinalTrackPositionID,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Position_NestPositionID",
                        column: x => x.NestPositionID,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Position_SixthPositionID",
                        column: x => x.SixthPositionID,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piece_Position_StartPositionID",
                        column: x => x.StartPositionID,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Move_BoardID",
                table: "Move",
                column: "BoardID");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_CurrentPositionID",
                table: "Piece",
                column: "CurrentPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_EnterFinalTrackPositionID",
                table: "Piece",
                column: "EnterFinalTrackPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_NestPositionID",
                table: "Piece",
                column: "NestPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_PlayerID",
                table: "Piece",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_SixthPositionID",
                table: "Piece",
                column: "SixthPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Piece_StartPositionID",
                table: "Piece",
                column: "StartPositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Move");

            migrationBuilder.DropTable(
                name: "Piece");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
