using Microsoft.EntityFrameworkCore.Migrations;

namespace SuLnu.DAL.Migrations
{
    public partial class Add_News_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Universities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoFilePath",
                table: "Universities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Faculties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoFilePath",
                table: "Faculties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Documnets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Tilte = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PhotoFilePath = table.Column<string>(nullable: true),
                    FacultyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_FacultyId",
                table: "News",
                column: "FacultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "LogoFilePath",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "LogoFilePath",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Documnets");
        }
    }
}
