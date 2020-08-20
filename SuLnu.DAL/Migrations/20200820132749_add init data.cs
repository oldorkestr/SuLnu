using Microsoft.EntityFrameworkCore.Migrations;

namespace SuLnu.DAL.Migrations
{
    public partial class addinitdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Description", "Email", "LogoFilePath", "Name", "PhoneNumber" },
                values: new object[] { 1, null, null, null, "LNU", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
