using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuckleUp.Migrations
{
    public partial class RemovedQuizFromPersonalUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_PersonalUsers_PersonalUserId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_PersonalUserId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "PersonalUserId",
                table: "Quizzes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PersonalUserId",
                table: "Quizzes",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_PersonalUserId",
                table: "Quizzes",
                column: "PersonalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_PersonalUsers_PersonalUserId",
                table: "Quizzes",
                column: "PersonalUserId",
                principalTable: "PersonalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
