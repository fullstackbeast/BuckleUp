using Microsoft.EntityFrameworkCore.Migrations;

namespace BuckleUp.Migrations
{
    public partial class AddedLinkToQuizTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Quizzes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Quizzes");
        }
    }
}
