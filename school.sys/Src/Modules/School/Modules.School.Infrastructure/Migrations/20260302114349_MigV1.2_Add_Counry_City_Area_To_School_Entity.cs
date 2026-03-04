using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.School.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigV12_Add_Counry_City_Area_To_School_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AreaId",
                table: "Schools",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Schools",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Schools",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Schools_AreaId",
                table: "Schools",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_CityId",
                table: "Schools",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_CountryId",
                table: "Schools",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Areas_AreaId",
                table: "Schools",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Cities_CityId",
                table: "Schools",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Countries_CountryId",
                table: "Schools",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Areas_AreaId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Cities_CityId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Countries_CountryId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_AreaId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_CityId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_CountryId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Schools");
        }
    }
}
