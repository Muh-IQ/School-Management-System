using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.IdP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SyncDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "user",
                table: "Users",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "NOT_WORK_12312dfgfdg123532ed_For_testing_porpuse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "user",
                table: "Users");
        }
    }
}
