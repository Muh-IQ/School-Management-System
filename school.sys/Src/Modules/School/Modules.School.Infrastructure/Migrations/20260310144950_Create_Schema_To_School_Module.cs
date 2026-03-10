using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.School.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Schema_To_School_Module : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "school");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "Schools",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "Policies",
                newName: "Policies",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Languages",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Countries",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "Cities",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "Areas",
                newName: "Areas",
                newSchema: "school");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Schools",
                schema: "school",
                newName: "Schools");

            migrationBuilder.RenameTable(
                name: "Policies",
                schema: "school",
                newName: "Policies");

            migrationBuilder.RenameTable(
                name: "Languages",
                schema: "school",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "Countries",
                schema: "school",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Cities",
                schema: "school",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Areas",
                schema: "school",
                newName: "Areas");
        }
    }
}
