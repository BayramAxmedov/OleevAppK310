using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OleevAppK310.Migrations
{
    public partial class seks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fact_1",
                table: "Fact_1");

            migrationBuilder.RenameTable(
                name: "Fact_1",
                newName: "Fatcs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fatcs",
                table: "Fatcs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fatcs",
                table: "Fatcs");

            migrationBuilder.RenameTable(
                name: "Fatcs",
                newName: "Fact_1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fact_1",
                table: "Fact_1",
                column: "Id");
        }
    }
}
