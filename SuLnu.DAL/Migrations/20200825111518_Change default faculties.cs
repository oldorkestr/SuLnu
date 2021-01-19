using Microsoft.EntityFrameworkCore.Migrations;

namespace SuLnu.DAL.Migrations
{
    public partial class Changedefaultfaculties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "AMI");

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Description", "Email", "LogoFilePath", "Name", "UniversityId" },
                values: new object[] { 5, null, null, null, "General", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Applied mathematics and computer science");
        }
    }
}
