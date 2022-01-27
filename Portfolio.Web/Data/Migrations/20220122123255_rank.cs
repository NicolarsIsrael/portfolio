using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Web.Data.Migrations
{
    public partial class rank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Project",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Project");
        }
    }
}
