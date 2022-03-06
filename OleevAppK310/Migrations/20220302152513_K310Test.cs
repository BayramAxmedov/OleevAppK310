using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OleevAppK310.Migrations
{
    public partial class K310Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "services",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "services");
        }
    }
}
