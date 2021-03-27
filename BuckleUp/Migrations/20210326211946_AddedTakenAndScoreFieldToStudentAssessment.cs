using Microsoft.EntityFrameworkCore.Migrations;

namespace BuckleUp.Migrations
{
    public partial class AddedTakenAndScoreFieldToStudentAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasTaken",
                table: "StudentAssessment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "score",
                table: "StudentAssessment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasTaken",
                table: "StudentAssessment");

            migrationBuilder.DropColumn(
                name: "score",
                table: "StudentAssessment");
        }
    }
}
