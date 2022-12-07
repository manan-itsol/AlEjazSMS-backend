using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlEjazSMS.Migrations
{
    public partial class StudentFeeStructuresAndDOBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_FeeStructures_FeeStructureId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FeeStructureId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FeeStructureId",
                table: "Students");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "StudentFeeStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    FeeStructureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFeeStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFeeStructures_FeeStructures_FeeStructureId",
                        column: x => x.FeeStructureId,
                        principalTable: "FeeStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentFeeStructures_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentFeeStructures_FeeStructureId",
                table: "StudentFeeStructures",
                column: "FeeStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFeeStructures_StudentId_FeeStructureId",
                table: "StudentFeeStructures",
                columns: new[] { "StudentId", "FeeStructureId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentFeeStructures");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "FeeStructureId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FeeStructureId",
                table: "Students",
                column: "FeeStructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_FeeStructures_FeeStructureId",
                table: "Students",
                column: "FeeStructureId",
                principalTable: "FeeStructures",
                principalColumn: "Id");
        }
    }
}
