using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class ModelEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Mails",
                newName: "TemplateId");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Mails",
                newName: "ApiKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "Mails",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "ApiKey",
                table: "Mails",
                newName: "Password");
        }
    }
}
