using Microsoft.EntityFrameworkCore.Migrations;

namespace SuLnu.DAL.Migrations
{
    public partial class addinitdataFaculties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Description", "Email", "LogoFilePath", "Name", "UniversityId" },
                values: new object[,]
                {
                    { 1, null, null, null, "Applied mathematics and computer science", 1 },
                    { 2, null, null, null, "Electronics", 1 },
                    { 3, null, null, null, "Philology", 1 },
                    { 4, null, null, null, "Mechanics and Mathematics", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
