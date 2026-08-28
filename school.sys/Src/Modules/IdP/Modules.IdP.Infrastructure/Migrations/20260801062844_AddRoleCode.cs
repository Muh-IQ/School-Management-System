using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.IdP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "user",
                table: "Roles",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Code_IsActive",
                schema: "user",
                table: "Roles",
                columns: new[] { "Code", "IsActive" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_Code_IsActive",
                schema: "user",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "user",
                table: "Roles");
        }
    }
}
