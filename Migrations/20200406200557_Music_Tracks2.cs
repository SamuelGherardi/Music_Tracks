using Microsoft.EntityFrameworkCore.Migrations;

namespace Music_Tracks.Migrations
{
    public partial class Music_Tracks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Track",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Track");
        }
    }
}
