using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlEjazSMS.Migrations
{
    public partial class StudentClassAndSectionRelationshipImprovementMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Classes_ClassId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Sections_SectionId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Sections_ClassId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Students",
                newName: "ClassSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SectionId",
                table: "Students",
                newName: "IX_Students_ClassSectionId");

            migrationBuilder.CreateTable(
                name: "ClassSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSections_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_RollNo_ClassSectionId",
                table: "Students",
                columns: new[] { "RollNo", "ClassSectionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassSections_ClassId",
                table: "ClassSections",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSections_SectionId_ClassId",
                table: "ClassSections",
                columns: new[] { "SectionId", "ClassId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassSections_ClassSectionId",
                table: "Students",
                column: "ClassSectionId",
                principalTable: "ClassSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassSections_ClassSectionId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ClassSections");

            migrationBuilder.DropIndex(
                name: "IX_Students_RollNo_ClassSectionId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ClassSectionId",
                table: "Students",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassSectionId",
                table: "Students",
                newName: "IX_Students_SectionId");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ClassId",
                table: "Sections",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Classes_ClassId",
                table: "Sections",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Sections_SectionId",
                table: "Students",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
