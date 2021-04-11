using Microsoft.EntityFrameworkCore.Migrations;

namespace LudoGame.Migrations
{
    public partial class AddedPlayerIDtoMove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Move",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Move");
        }
    }
}
