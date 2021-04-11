using Microsoft.EntityFrameworkCore.Migrations;

namespace LudoGame.Migrations
{
    public partial class AddedAIPlayerDBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AIPlayerID",
                table: "Piece",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AIPlayer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIPlayer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piece_AIPlayerID",
                table: "Piece",
                column: "AIPlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_AIPlayer_AIPlayerID",
                table: "Piece",
                column: "AIPlayerID",
                principalTable: "AIPlayer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piece_AIPlayer_AIPlayerID",
                table: "Piece");

            migrationBuilder.DropTable(
                name: "AIPlayer");

            migrationBuilder.DropIndex(
                name: "IX_Piece_AIPlayerID",
                table: "Piece");

            migrationBuilder.DropColumn(
                name: "AIPlayerID",
                table: "Piece");
        }
    }
}
