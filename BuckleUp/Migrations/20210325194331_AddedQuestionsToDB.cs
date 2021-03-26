using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuckleUp.Migrations
{
    public partial class AddedQuestionsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Teachers_TeacherId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.AlterColumn<byte[]>(
                name: "TeacherId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "TeacherId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    AssessmentId = table.Column<byte[]>(nullable: false),
                    Option1 = table.Column<string>(nullable: true),
                    Option2 = table.Column<string>(nullable: true),
                    Option3 = table.Column<string>(nullable: true),
                    Option4 = table.Column<string>(nullable: true),
                    CorrectOption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AssessmentId",
                table: "Questions",
                column: "AssessmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Teachers_TeacherId",
                table: "Assessments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Teachers_TeacherId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.AlterColumn<byte[]>(
                name: "TeacherId",
                table: "Courses",
                type: "varbinary(16)",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<byte[]>(
                name: "TeacherId",
                table: "Assessments",
                type: "varbinary(16)",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Teachers_TeacherId",
                table: "Assessments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
