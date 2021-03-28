using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuckleUp.Migrations
{
    public partial class SeperatedAssessmentAndQuizQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.CreateTable(
                name: "AssessmentQuestions",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    QuestionText = table.Column<string>(nullable: true),
                    Option1 = table.Column<string>(nullable: true),
                    Option2 = table.Column<string>(nullable: true),
                    Option3 = table.Column<string>(nullable: true),
                    Option4 = table.Column<string>(nullable: true),
                    CorrectOption = table.Column<string>(nullable: true),
                    AssessmentId = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentQuestions_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    QuestionText = table.Column<string>(nullable: true),
                    Option1 = table.Column<string>(nullable: true),
                    Option2 = table.Column<string>(nullable: true),
                    Option3 = table.Column<string>(nullable: true),
                    Option4 = table.Column<string>(nullable: true),
                    CorrectOption = table.Column<string>(nullable: true),
                    QuizId = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentQuestions_AssessmentId",
                table: "AssessmentQuestions",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId",
                table: "QuizQuestions",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentQuestions");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    AssessmentId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CorrectOption = table.Column<string>(type: "text", nullable: true),
                    Option1 = table.Column<string>(type: "text", nullable: true),
                    Option2 = table.Column<string>(type: "text", nullable: true),
                    Option3 = table.Column<string>(type: "text", nullable: true),
                    Option4 = table.Column<string>(type: "text", nullable: true),
                    QuestionText = table.Column<string>(type: "text", nullable: true),
                    QuizId = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AssessmentId",
                table: "Questions",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");
        }
    }
}
