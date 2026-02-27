using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.School.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpolicyseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "Description", "IsActive", "IsDefault", "Title", "sanitizeName" },
                values: new object[] { new Guid("12112121-2121-2121-2121-121212121212"), "This policy defines the general operational and behavioral guidelines applicable to all schools unless otherwise specified.", true, true, "General School Policy", "general-school-policy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("12112121-2121-2121-2121-121212121212"));
        }
    }
}
