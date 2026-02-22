using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modules.School.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationEntitiesWithSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), true, false, "Iraq" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), true, false, "United States" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), true, false, "United Kingdom" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), true, false, "Canada" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), true, false, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("a0000001-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), true, false, "Baghdad" },
                    { new Guid("a0000002-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), true, false, "Basra" },
                    { new Guid("a0000003-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), true, false, "Mosul" },
                    { new Guid("a0000004-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), true, false, "Erbil" },
                    { new Guid("a0000005-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), true, false, "Kirkuk" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "CityId", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("b0000001-0000-0000-0000-000000000001"), new Guid("a0000001-0000-0000-0000-000000000001"), true, false, "Karkh" },
                    { new Guid("b0000002-0000-0000-0000-000000000002"), new Guid("a0000001-0000-0000-0000-000000000001"), true, false, "Rusafa" },
                    { new Guid("b0000003-0000-0000-0000-000000000003"), new Guid("a0000002-0000-0000-0000-000000000002"), true, false, "Al-Fao" },
                    { new Guid("b0000004-0000-0000-0000-000000000004"), new Guid("a0000002-0000-0000-0000-000000000002"), true, false, "Shatt Al-Arab" },
                    { new Guid("b0000005-0000-0000-0000-000000000005"), new Guid("a0000003-0000-0000-0000-000000000003"), true, false, "Old City" },
                    { new Guid("b0000006-0000-0000-0000-000000000006"), new Guid("a0000003-0000-0000-0000-000000000003"), true, false, "Nineveh Plains" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
