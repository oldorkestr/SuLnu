using Microsoft.EntityFrameworkCore.Migrations;

namespace SuLnu.DAL.Migrations
{
    public partial class Add_Documents_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documnets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DocumentFilePath = table.Column<string>(nullable: true),
                    FacultyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documnets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documnets_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documnets_FacultyId",
                table: "Documnets",
                column: "FacultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documnets");
        }
    }
}
