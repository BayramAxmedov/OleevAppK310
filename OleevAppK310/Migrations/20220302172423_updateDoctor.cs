using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OleevAppK310.Migrations
{
    public partial class updateDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservs_doctors_DoctorId1",
                table: "reservs");

            migrationBuilder.DropIndex(
                name: "IX_reservs_DoctorId1",
                table: "reservs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_doctors",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "reservs");

            migrationBuilder.RenameTable(
                name: "doctors",
                newName: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "reservs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_reservs_DoctorId",
                table: "reservs",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservs_Doctors_DoctorId",
                table: "reservs",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservs_Doctors_DoctorId",
                table: "reservs");

            migrationBuilder.DropIndex(
                name: "IX_reservs_DoctorId",
                table: "reservs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "doctors");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "reservs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "reservs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_doctors",
                table: "doctors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_reservs_DoctorId1",
                table: "reservs",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_reservs_doctors_DoctorId1",
                table: "reservs",
                column: "DoctorId1",
                principalTable: "doctors",
                principalColumn: "Id");
        }
    }
}
