using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modules.IdP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "user",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreateAt", "IsActive", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "SUPER_ADMIN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Super Administrator", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "SCHOOL_ADMIN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "School Administrator", null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "TEACHER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Teacher", null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "STUDENT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Student", null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "PARENT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Parent", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "user",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "user",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "user",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "user",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "user",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));
        }
    }
}
