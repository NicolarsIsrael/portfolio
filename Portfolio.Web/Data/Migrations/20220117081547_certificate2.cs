using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Web.Data.Migrations
{
    public partial class certificate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Certificate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Certificate");
        }
    }
}
