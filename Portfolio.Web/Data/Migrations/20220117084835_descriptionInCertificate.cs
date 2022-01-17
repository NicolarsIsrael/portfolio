using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Web.Data.Migrations
{
    public partial class descriptionInCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descritption",
                table: "Certificate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descritption",
                table: "Certificate");
        }
    }
}
