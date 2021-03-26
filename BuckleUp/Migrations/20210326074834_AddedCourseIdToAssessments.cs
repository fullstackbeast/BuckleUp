using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuckleUp.Migrations
{
    public partial class AddedCourseIdToAssessments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Courses_CourseId",
                table: "Assessments");

            migrationBuilder.AlterColumn<byte[]>(
                name: "CourseId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Courses_CourseId",
                table: "Assessments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Courses_CourseId",
                table: "Assessments");

            migrationBuilder.AlterColumn<byte[]>(
                name: "CourseId",
                table: "Assessments",
                type: "varbinary(16)",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Courses_CourseId",
                table: "Assessments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
