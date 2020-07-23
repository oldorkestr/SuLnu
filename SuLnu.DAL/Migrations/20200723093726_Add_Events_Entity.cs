using Microsoft.EntityFrameworkCore.Migrations;

namespace SuLnu.DAL.Migrations
{
    public partial class Add_Events_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FormOfHolding = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ProfilePhotoFilePath = table.Column<string>(nullable: true),
                    EventType = table.Column<string>(nullable: true),
                    FacultyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_FacultyId",
                table: "Events",
                column: "FacultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
