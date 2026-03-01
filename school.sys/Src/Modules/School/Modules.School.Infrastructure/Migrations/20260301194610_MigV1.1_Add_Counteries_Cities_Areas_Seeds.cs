using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modules.School.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigV11_Add_Counteries_Cities_Areas_Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b0000002-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b0000003-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b0000004-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b0000005-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b0000006-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a0000004-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a0000005-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a0000001-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a0000002-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a0000003-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), true, false, "Afghanistan" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), true, false, "Albania" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), true, false, "Algeria" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), true, false, "Andorra" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), true, false, "Angola" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), true, false, "Antigua and Barbuda" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), true, false, "Argentina" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), true, false, "Armenia" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), true, false, "Australia" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), true, false, "Austria" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), true, false, "Azerbaijan" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), true, false, "Bahamas" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), true, false, "Bahrain" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), true, false, "Bangladesh" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), true, false, "Barbados" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), true, false, "Belarus" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), true, false, "Belgium" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), true, false, "Belize" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), true, false, "Benin" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), true, false, "Bhutan" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), true, false, "Bolivia" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), true, false, "Bosnia and Herzegovina" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), true, false, "Botswana" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), true, false, "Brazil" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), true, false, "Brunei" },
                    { new Guid("00000000-0000-0000-0000-000000000026"), true, false, "Bulgaria" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), true, false, "Burkina Faso" },
                    { new Guid("00000000-0000-0000-0000-000000000028"), true, false, "Burundi" },
                    { new Guid("00000000-0000-0000-0000-000000000029"), true, false, "Cabo Verde" },
                    { new Guid("00000000-0000-0000-0000-000000000030"), true, false, "Cambodia" },
                    { new Guid("00000000-0000-0000-0000-000000000031"), true, false, "Cameroon" },
                    { new Guid("00000000-0000-0000-0000-000000000032"), true, false, "Canada" },
                    { new Guid("00000000-0000-0000-0000-000000000033"), true, false, "Central African Republic" },
                    { new Guid("00000000-0000-0000-0000-000000000034"), true, false, "Chad" },
                    { new Guid("00000000-0000-0000-0000-000000000035"), true, false, "Chile" },
                    { new Guid("00000000-0000-0000-0000-000000000036"), true, false, "China" },
                    { new Guid("00000000-0000-0000-0000-000000000037"), true, false, "Colombia" },
                    { new Guid("00000000-0000-0000-0000-000000000038"), true, false, "Comoros" },
                    { new Guid("00000000-0000-0000-0000-000000000039"), true, false, "Congo" },
                    { new Guid("00000000-0000-0000-0000-000000000040"), true, false, "Costa Rica" },
                    { new Guid("00000000-0000-0000-0000-000000000041"), true, false, "Croatia" },
                    { new Guid("00000000-0000-0000-0000-000000000042"), true, false, "Cuba" },
                    { new Guid("00000000-0000-0000-0000-000000000043"), true, false, "Cyprus" },
                    { new Guid("00000000-0000-0000-0000-000000000044"), true, false, "Czech Republic" },
                    { new Guid("00000000-0000-0000-0000-000000000045"), true, false, "Denmark" },
                    { new Guid("00000000-0000-0000-0000-000000000046"), true, false, "Djibouti" },
                    { new Guid("00000000-0000-0000-0000-000000000047"), true, false, "Dominica" },
                    { new Guid("00000000-0000-0000-0000-000000000048"), true, false, "Dominican Republic" },
                    { new Guid("00000000-0000-0000-0000-000000000049"), true, false, "Ecuador" },
                    { new Guid("00000000-0000-0000-0000-000000000050"), true, false, "Egypt" },
                    { new Guid("00000000-0000-0000-0000-000000000051"), true, false, "El Salvador" },
                    { new Guid("00000000-0000-0000-0000-000000000052"), true, false, "Equatorial Guinea" },
                    { new Guid("00000000-0000-0000-0000-000000000053"), true, false, "Eritrea" },
                    { new Guid("00000000-0000-0000-0000-000000000054"), true, false, "Estonia" },
                    { new Guid("00000000-0000-0000-0000-000000000055"), true, false, "Eswatini" },
                    { new Guid("00000000-0000-0000-0000-000000000056"), true, false, "Ethiopia" },
                    { new Guid("00000000-0000-0000-0000-000000000057"), true, false, "Fiji" },
                    { new Guid("00000000-0000-0000-0000-000000000058"), true, false, "Finland" },
                    { new Guid("00000000-0000-0000-0000-000000000059"), true, false, "France" },
                    { new Guid("00000000-0000-0000-0000-000000000060"), true, false, "Gabon" },
                    { new Guid("00000000-0000-0000-0000-000000000061"), true, false, "Gambia" },
                    { new Guid("00000000-0000-0000-0000-000000000062"), true, false, "Georgia" },
                    { new Guid("00000000-0000-0000-0000-000000000063"), true, false, "Germany" },
                    { new Guid("00000000-0000-0000-0000-000000000064"), true, false, "Ghana" },
                    { new Guid("00000000-0000-0000-0000-000000000065"), true, false, "Greece" },
                    { new Guid("00000000-0000-0000-0000-000000000066"), true, false, "Grenada" },
                    { new Guid("00000000-0000-0000-0000-000000000067"), true, false, "Guatemala" },
                    { new Guid("00000000-0000-0000-0000-000000000068"), true, false, "Guinea" },
                    { new Guid("00000000-0000-0000-0000-000000000069"), true, false, "Guinea-Bissau" },
                    { new Guid("00000000-0000-0000-0000-000000000070"), true, false, "Guyana" },
                    { new Guid("00000000-0000-0000-0000-000000000071"), true, false, "Haiti" },
                    { new Guid("00000000-0000-0000-0000-000000000072"), true, false, "Honduras" },
                    { new Guid("00000000-0000-0000-0000-000000000073"), true, false, "Hungary" },
                    { new Guid("00000000-0000-0000-0000-000000000074"), true, false, "Iceland" },
                    { new Guid("00000000-0000-0000-0000-000000000075"), true, false, "India" },
                    { new Guid("00000000-0000-0000-0000-000000000076"), true, false, "Indonesia" },
                    { new Guid("00000000-0000-0000-0000-000000000077"), true, false, "Iran" },
                    { new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Iraq" },
                    { new Guid("00000000-0000-0000-0000-000000000079"), true, false, "Ireland" },
                    { new Guid("00000000-0000-0000-0000-000000000080"), true, false, "Israel" },
                    { new Guid("00000000-0000-0000-0000-000000000081"), true, false, "Italy" },
                    { new Guid("00000000-0000-0000-0000-000000000082"), true, false, "Jamaica" },
                    { new Guid("00000000-0000-0000-0000-000000000083"), true, false, "Japan" },
                    { new Guid("00000000-0000-0000-0000-000000000084"), true, false, "Jordan" },
                    { new Guid("00000000-0000-0000-0000-000000000085"), true, false, "Kazakhstan" },
                    { new Guid("00000000-0000-0000-0000-000000000086"), true, false, "Kenya" },
                    { new Guid("00000000-0000-0000-0000-000000000087"), true, false, "Kiribati" },
                    { new Guid("00000000-0000-0000-0000-000000000088"), true, false, "Kuwait" },
                    { new Guid("00000000-0000-0000-0000-000000000089"), true, false, "Kyrgyzstan" },
                    { new Guid("00000000-0000-0000-0000-000000000090"), true, false, "Laos" },
                    { new Guid("00000000-0000-0000-0000-000000000091"), true, false, "Latvia" },
                    { new Guid("00000000-0000-0000-0000-000000000092"), true, false, "Lebanon" },
                    { new Guid("00000000-0000-0000-0000-000000000093"), true, false, "Lesotho" },
                    { new Guid("00000000-0000-0000-0000-000000000094"), true, false, "Liberia" },
                    { new Guid("00000000-0000-0000-0000-000000000095"), true, false, "Libya" },
                    { new Guid("00000000-0000-0000-0000-000000000096"), true, false, "Liechtenstein" },
                    { new Guid("00000000-0000-0000-0000-000000000097"), true, false, "Lithuania" },
                    { new Guid("00000000-0000-0000-0000-000000000098"), true, false, "Luxembourg" },
                    { new Guid("00000000-0000-0000-0000-000000000099"), true, false, "Madagascar" },
                    { new Guid("00000000-0000-0000-0000-000000000100"), true, false, "Malawi" },
                    { new Guid("00000000-0000-0000-0000-000000000101"), true, false, "Malaysia" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), true, false, "Maldives" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), true, false, "Mali" },
                    { new Guid("00000000-0000-0000-0000-000000000104"), true, false, "Malta" },
                    { new Guid("00000000-0000-0000-0000-000000000105"), true, false, "Marshall Islands" },
                    { new Guid("00000000-0000-0000-0000-000000000106"), true, false, "Mauritania" },
                    { new Guid("00000000-0000-0000-0000-000000000107"), true, false, "Mauritius" },
                    { new Guid("00000000-0000-0000-0000-000000000108"), true, false, "Mexico" },
                    { new Guid("00000000-0000-0000-0000-000000000109"), true, false, "Micronesia" },
                    { new Guid("00000000-0000-0000-0000-000000000110"), true, false, "Moldova" },
                    { new Guid("00000000-0000-0000-0000-000000000111"), true, false, "Monaco" },
                    { new Guid("00000000-0000-0000-0000-000000000112"), true, false, "Mongolia" },
                    { new Guid("00000000-0000-0000-0000-000000000113"), true, false, "Montenegro" },
                    { new Guid("00000000-0000-0000-0000-000000000114"), true, false, "Morocco" },
                    { new Guid("00000000-0000-0000-0000-000000000115"), true, false, "Mozambique" },
                    { new Guid("00000000-0000-0000-0000-000000000116"), true, false, "Myanmar" },
                    { new Guid("00000000-0000-0000-0000-000000000117"), true, false, "Namibia" },
                    { new Guid("00000000-0000-0000-0000-000000000118"), true, false, "Nauru" },
                    { new Guid("00000000-0000-0000-0000-000000000119"), true, false, "Nepal" },
                    { new Guid("00000000-0000-0000-0000-000000000120"), true, false, "Netherlands" },
                    { new Guid("00000000-0000-0000-0000-000000000121"), true, false, "New Zealand" },
                    { new Guid("00000000-0000-0000-0000-000000000122"), true, false, "Nicaragua" },
                    { new Guid("00000000-0000-0000-0000-000000000123"), true, false, "Niger" },
                    { new Guid("00000000-0000-0000-0000-000000000124"), true, false, "Nigeria" },
                    { new Guid("00000000-0000-0000-0000-000000000125"), true, false, "North Korea" },
                    { new Guid("00000000-0000-0000-0000-000000000126"), true, false, "North Macedonia" },
                    { new Guid("00000000-0000-0000-0000-000000000127"), true, false, "Norway" },
                    { new Guid("00000000-0000-0000-0000-000000000128"), true, false, "Oman" },
                    { new Guid("00000000-0000-0000-0000-000000000129"), true, false, "Pakistan" },
                    { new Guid("00000000-0000-0000-0000-000000000130"), true, false, "Palau" },
                    { new Guid("00000000-0000-0000-0000-000000000131"), true, false, "Palestine" },
                    { new Guid("00000000-0000-0000-0000-000000000132"), true, false, "Panama" },
                    { new Guid("00000000-0000-0000-0000-000000000133"), true, false, "Papua New Guinea" },
                    { new Guid("00000000-0000-0000-0000-000000000134"), true, false, "Paraguay" },
                    { new Guid("00000000-0000-0000-0000-000000000135"), true, false, "Peru" },
                    { new Guid("00000000-0000-0000-0000-000000000136"), true, false, "Philippines" },
                    { new Guid("00000000-0000-0000-0000-000000000137"), true, false, "Poland" },
                    { new Guid("00000000-0000-0000-0000-000000000138"), true, false, "Portugal" },
                    { new Guid("00000000-0000-0000-0000-000000000139"), true, false, "Qatar" },
                    { new Guid("00000000-0000-0000-0000-000000000140"), true, false, "Romania" },
                    { new Guid("00000000-0000-0000-0000-000000000141"), true, false, "Russia" },
                    { new Guid("00000000-0000-0000-0000-000000000142"), true, false, "Rwanda" },
                    { new Guid("00000000-0000-0000-0000-000000000143"), true, false, "Saint Kitts and Nevis" },
                    { new Guid("00000000-0000-0000-0000-000000000144"), true, false, "Saint Lucia" },
                    { new Guid("00000000-0000-0000-0000-000000000145"), true, false, "Saint Vincent and the Grenadines" },
                    { new Guid("00000000-0000-0000-0000-000000000146"), true, false, "Samoa" },
                    { new Guid("00000000-0000-0000-0000-000000000147"), true, false, "San Marino" },
                    { new Guid("00000000-0000-0000-0000-000000000148"), true, false, "Sao Tome and Principe" },
                    { new Guid("00000000-0000-0000-0000-000000000149"), true, false, "Saudi Arabia" },
                    { new Guid("00000000-0000-0000-0000-000000000150"), true, false, "Senegal" },
                    { new Guid("00000000-0000-0000-0000-000000000151"), true, false, "Serbia" },
                    { new Guid("00000000-0000-0000-0000-000000000152"), true, false, "Seychelles" },
                    { new Guid("00000000-0000-0000-0000-000000000153"), true, false, "Sierra Leone" },
                    { new Guid("00000000-0000-0000-0000-000000000154"), true, false, "Singapore" },
                    { new Guid("00000000-0000-0000-0000-000000000155"), true, false, "Slovakia" },
                    { new Guid("00000000-0000-0000-0000-000000000156"), true, false, "Slovenia" },
                    { new Guid("00000000-0000-0000-0000-000000000157"), true, false, "Solomon Islands" },
                    { new Guid("00000000-0000-0000-0000-000000000158"), true, false, "Somalia" },
                    { new Guid("00000000-0000-0000-0000-000000000159"), true, false, "South Africa" },
                    { new Guid("00000000-0000-0000-0000-000000000160"), true, false, "South Korea" },
                    { new Guid("00000000-0000-0000-0000-000000000161"), true, false, "South Sudan" },
                    { new Guid("00000000-0000-0000-0000-000000000162"), true, false, "Spain" },
                    { new Guid("00000000-0000-0000-0000-000000000163"), true, false, "Sri Lanka" },
                    { new Guid("00000000-0000-0000-0000-000000000164"), true, false, "Sudan" },
                    { new Guid("00000000-0000-0000-0000-000000000165"), true, false, "Suriname" },
                    { new Guid("00000000-0000-0000-0000-000000000166"), true, false, "Sweden" },
                    { new Guid("00000000-0000-0000-0000-000000000167"), true, false, "Switzerland" },
                    { new Guid("00000000-0000-0000-0000-000000000168"), true, false, "Syria" },
                    { new Guid("00000000-0000-0000-0000-000000000169"), true, false, "Tajikistan" },
                    { new Guid("00000000-0000-0000-0000-000000000170"), true, false, "Tanzania" },
                    { new Guid("00000000-0000-0000-0000-000000000171"), true, false, "Thailand" },
                    { new Guid("00000000-0000-0000-0000-000000000172"), true, false, "Timor-Leste" },
                    { new Guid("00000000-0000-0000-0000-000000000173"), true, false, "Togo" },
                    { new Guid("00000000-0000-0000-0000-000000000174"), true, false, "Tonga" },
                    { new Guid("00000000-0000-0000-0000-000000000175"), true, false, "Trinidad and Tobago" },
                    { new Guid("00000000-0000-0000-0000-000000000176"), true, false, "Tunisia" },
                    { new Guid("00000000-0000-0000-0000-000000000177"), true, false, "Turkey" },
                    { new Guid("00000000-0000-0000-0000-000000000178"), true, false, "Turkmenistan" },
                    { new Guid("00000000-0000-0000-0000-000000000179"), true, false, "Tuvalu" },
                    { new Guid("00000000-0000-0000-0000-000000000180"), true, false, "Uganda" },
                    { new Guid("00000000-0000-0000-0000-000000000181"), true, false, "Ukraine" },
                    { new Guid("00000000-0000-0000-0000-000000000182"), true, false, "United Arab Emirates" },
                    { new Guid("00000000-0000-0000-0000-000000000183"), true, false, "United Kingdom" },
                    { new Guid("00000000-0000-0000-0000-000000000184"), true, false, "United States" },
                    { new Guid("00000000-0000-0000-0000-000000000185"), true, false, "Uruguay" },
                    { new Guid("00000000-0000-0000-0000-000000000186"), true, false, "Uzbekistan" },
                    { new Guid("00000000-0000-0000-0000-000000000187"), true, false, "Vanuatu" },
                    { new Guid("00000000-0000-0000-0000-000000000188"), true, false, "Vatican City" },
                    { new Guid("00000000-0000-0000-0000-000000000189"), true, false, "Venezuela" },
                    { new Guid("00000000-0000-0000-0000-000000000190"), true, false, "Vietnam" },
                    { new Guid("00000000-0000-0000-0000-000000000191"), true, false, "Yemen" },
                    { new Guid("00000000-0000-0000-0000-000000000192"), true, false, "Zambia" },
                    { new Guid("00000000-0000-0000-0000-000000000193"), true, false, "Zimbabwe" },
                    { new Guid("00000000-0000-0000-0000-000000000194"), true, false, "Kosovo" },
                    { new Guid("00000000-0000-0000-0000-000000000195"), true, false, "Taiwan" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("00000001-0001-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Baghdad" },
                    { new Guid("00000001-0002-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Basra" },
                    { new Guid("00000001-0003-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Mosul" },
                    { new Guid("00000001-0004-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Erbil" },
                    { new Guid("00000001-0005-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Kirkuk" },
                    { new Guid("00000001-0006-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Najaf" },
                    { new Guid("00000001-0007-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Karbala" },
                    { new Guid("00000001-0008-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Sulaymaniyah" },
                    { new Guid("00000001-0009-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Dohuk" },
                    { new Guid("00000001-0010-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Diyala" },
                    { new Guid("00000001-0011-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Babil" },
                    { new Guid("00000001-0012-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Anbar" },
                    { new Guid("00000001-0013-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Wasit" },
                    { new Guid("00000001-0014-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Dhi Qar" },
                    { new Guid("00000001-0015-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Maysan" },
                    { new Guid("00000001-0016-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Qadisiyah" },
                    { new Guid("00000001-0017-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Salah al-Din" },
                    { new Guid("00000001-0018-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000078"), true, false, "Nineveh" },
                    { new Guid("00000002-0001-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Alabama" },
                    { new Guid("00000002-0002-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Alaska" },
                    { new Guid("00000002-0003-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Arizona" },
                    { new Guid("00000002-0004-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Arkansas" },
                    { new Guid("00000002-0005-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "California" },
                    { new Guid("00000002-0006-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Colorado" },
                    { new Guid("00000002-0007-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Connecticut" },
                    { new Guid("00000002-0008-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Delaware" },
                    { new Guid("00000002-0009-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Florida" },
                    { new Guid("00000002-0010-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Georgia" },
                    { new Guid("00000002-0011-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Hawaii" },
                    { new Guid("00000002-0012-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Idaho" },
                    { new Guid("00000002-0013-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Illinois" },
                    { new Guid("00000002-0014-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Indiana" },
                    { new Guid("00000002-0015-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Iowa" },
                    { new Guid("00000002-0016-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Kansas" },
                    { new Guid("00000002-0017-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Kentucky" },
                    { new Guid("00000002-0018-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Louisiana" },
                    { new Guid("00000002-0019-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Maine" },
                    { new Guid("00000002-0020-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Maryland" },
                    { new Guid("00000002-0021-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Massachusetts" },
                    { new Guid("00000002-0022-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Michigan" },
                    { new Guid("00000002-0023-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Minnesota" },
                    { new Guid("00000002-0024-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Mississippi" },
                    { new Guid("00000002-0025-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Missouri" },
                    { new Guid("00000002-0026-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Montana" },
                    { new Guid("00000002-0027-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Nebraska" },
                    { new Guid("00000002-0028-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Nevada" },
                    { new Guid("00000002-0029-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "New Hampshire" },
                    { new Guid("00000002-0030-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "New Jersey" },
                    { new Guid("00000002-0031-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "New Mexico" },
                    { new Guid("00000002-0032-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "New York" },
                    { new Guid("00000002-0033-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "North Carolina" },
                    { new Guid("00000002-0034-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "North Dakota" },
                    { new Guid("00000002-0035-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Ohio" },
                    { new Guid("00000002-0036-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Oklahoma" },
                    { new Guid("00000002-0037-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Oregon" },
                    { new Guid("00000002-0038-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Pennsylvania" },
                    { new Guid("00000002-0039-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Rhode Island" },
                    { new Guid("00000002-0040-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "South Carolina" },
                    { new Guid("00000002-0041-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "South Dakota" },
                    { new Guid("00000002-0042-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Tennessee" },
                    { new Guid("00000002-0043-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Texas" },
                    { new Guid("00000002-0044-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Utah" },
                    { new Guid("00000002-0045-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Vermont" },
                    { new Guid("00000002-0046-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Virginia" },
                    { new Guid("00000002-0047-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Washington" },
                    { new Guid("00000002-0048-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "West Virginia" },
                    { new Guid("00000002-0049-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Wisconsin" },
                    { new Guid("00000002-0050-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000184"), true, false, "Wyoming" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "CityId", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("00000001-0001-0001-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Karkh" },
                    { new Guid("00000001-0001-0002-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Rusafa" },
                    { new Guid("00000001-0001-0003-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Karrada" },
                    { new Guid("00000001-0001-0004-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Adhamiyah" },
                    { new Guid("00000001-0001-0005-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Mansour" },
                    { new Guid("00000001-0001-0006-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Sadr City" },
                    { new Guid("00000001-0001-0007-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Dora" },
                    { new Guid("00000001-0001-0008-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Ghazaliya" },
                    { new Guid("00000001-0001-0009-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Amiriya" },
                    { new Guid("00000001-0001-0010-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Zayouna" },
                    { new Guid("00000001-0001-0011-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Palestine Street" },
                    { new Guid("00000001-0001-0012-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Hurriya" },
                    { new Guid("00000001-0001-0013-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Bayaa" },
                    { new Guid("00000001-0001-0014-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Shaab" },
                    { new Guid("00000001-0001-0015-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Jadiriyah" },
                    { new Guid("00000001-0001-0016-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Shurja" },
                    { new Guid("00000001-0001-0017-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Fadhil" },
                    { new Guid("00000001-0001-0018-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Sheikh Omar" },
                    { new Guid("00000001-0001-0019-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Jesr Diyala" },
                    { new Guid("00000001-0001-0020-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Abu Disher" },
                    { new Guid("00000001-0001-0021-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Yarmouk" },
                    { new Guid("00000001-0001-0022-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Hebnaa" },
                    { new Guid("00000001-0001-0023-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Mahmudiyah" },
                    { new Guid("00000001-0001-0024-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Bab Al Moatham" },
                    { new Guid("00000001-0001-0025-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Bab Al Sharqi" },
                    { new Guid("00000001-0001-0026-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Fathel" },
                    { new Guid("00000001-0001-0027-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Ubedy" },
                    { new Guid("00000001-0001-0028-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Washash" },
                    { new Guid("00000001-0001-0029-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Wazireya" },
                    { new Guid("00000001-0001-0030-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Hayy Ur" },
                    { new Guid("00000001-0001-0031-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Hayy Al Jamiya" },
                    { new Guid("00000001-0001-0032-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Adel" },
                    { new Guid("00000001-0001-0033-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Khadhraa" },
                    { new Guid("00000001-0001-0034-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Hayy Al Jihad" },
                    { new Guid("00000001-0001-0035-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Hayy Al Aamel" },
                    { new Guid("00000001-0001-0036-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Hayy Aoor" },
                    { new Guid("00000001-0001-0037-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Hayy Al Shurtta" },
                    { new Guid("00000001-0001-0038-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Iskan" },
                    { new Guid("00000001-0001-0039-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Gazaliyah" },
                    { new Guid("00000001-0001-0040-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Salam" },
                    { new Guid("00000001-0001-0041-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Intisar" },
                    { new Guid("00000001-0001-0042-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Baladiyat" },
                    { new Guid("00000001-0001-0043-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Dawoodi" },
                    { new Guid("00000001-0001-0044-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Dhuhbaat" },
                    { new Guid("00000001-0001-0045-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Elwiya" },
                    { new Guid("00000001-0001-0046-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Khansaa" },
                    { new Guid("00000001-0001-0047-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Latifiya" },
                    { new Guid("00000001-0001-0048-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Haifa Street" },
                    { new Guid("00000001-0001-0049-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Maidan" },
                    { new Guid("00000001-0001-0050-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Sinaa" },
                    { new Guid("00000001-0001-0051-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Karama" },
                    { new Guid("00000001-0001-0052-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Waziriya" },
                    { new Guid("00000001-0001-0053-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Mustansiriya" },
                    { new Guid("00000001-0001-0054-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Khaleej" },
                    { new Guid("00000001-0001-0055-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Khilani" },
                    { new Guid("00000001-0001-0056-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Amil" },
                    { new Guid("00000001-0001-0057-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Hurriya" },
                    { new Guid("00000001-0001-0058-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Harthiya" },
                    { new Guid("00000001-0001-0059-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Qahira" },
                    { new Guid("00000001-0001-0060-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Rasheed" },
                    { new Guid("00000001-0001-0061-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Nidal" },
                    { new Guid("00000001-0001-0062-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Shorja" },
                    { new Guid("00000001-0001-0063-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Mansour" },
                    { new Guid("00000001-0001-0064-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Shaab" },
                    { new Guid("00000001-0001-0065-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Hurriya" },
                    { new Guid("00000001-0001-0066-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Shurta" },
                    { new Guid("00000001-0001-0067-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Baladiyat" },
                    { new Guid("00000001-0001-0068-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Mansour" },
                    { new Guid("00000001-0001-0069-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Adel" },
                    { new Guid("00000001-0001-0070-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Kadhraa" },
                    { new Guid("00000001-0001-0071-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Zaafaran" },
                    { new Guid("00000001-0001-0072-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Khalis" },
                    { new Guid("00000001-0001-0073-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Rasheed" },
                    { new Guid("00000001-0001-0074-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Jadriya" },
                    { new Guid("00000001-0001-0075-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Maamil" },
                    { new Guid("00000001-0001-0076-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Hurriyah" },
                    { new Guid("00000001-0001-0077-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Rashid" },
                    { new Guid("00000001-0001-0078-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Mansour" },
                    { new Guid("00000001-0001-0079-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Shaab" },
                    { new Guid("00000001-0001-0080-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Kadisiya" },
                    { new Guid("00000001-0001-0081-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Ameen" },
                    { new Guid("00000001-0001-0082-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Salam" },
                    { new Guid("00000001-0001-0083-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Waziriyah" },
                    { new Guid("00000001-0001-0084-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Rashidiyah" },
                    { new Guid("00000001-0001-0085-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Mutanabbi" },
                    { new Guid("00000001-0001-0086-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Shurta" },
                    { new Guid("00000001-0001-0087-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Adel" },
                    { new Guid("00000001-0001-0088-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Khadhraa" },
                    { new Guid("00000001-0001-0089-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Qahira" },
                    { new Guid("00000001-0001-0090-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Hurriya" },
                    { new Guid("00000001-0001-0091-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Karama" },
                    { new Guid("00000001-0001-0092-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Maidan" },
                    { new Guid("00000001-0001-0093-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Shaab" },
                    { new Guid("00000001-0001-0094-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Baladiyat" },
                    { new Guid("00000001-0001-0095-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Jadriya" },
                    { new Guid("00000001-0001-0096-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Amiriya" },
                    { new Guid("00000001-0001-0097-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Dora" },
                    { new Guid("00000001-0001-0098-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Sadr City" },
                    { new Guid("00000001-0001-0099-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Karrada" },
                    { new Guid("00000001-0001-0100-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Rusafa" },
                    { new Guid("00000001-0001-0101-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Rashid" },
                    { new Guid("00000001-0001-0102-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Hurriyah" },
                    { new Guid("00000001-0001-0103-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Shaab" },
                    { new Guid("00000001-0001-0104-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Mansour" },
                    { new Guid("00000001-0001-0105-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Kadisiya" },
                    { new Guid("00000001-0001-0106-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Ameen" },
                    { new Guid("00000001-0001-0107-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Salam" },
                    { new Guid("00000001-0001-0108-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Waziriyah" },
                    { new Guid("00000001-0001-0109-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Rashidiyah" },
                    { new Guid("00000001-0001-0110-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Mutanabbi" },
                    { new Guid("00000001-0001-0111-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Shurta" },
                    { new Guid("00000001-0001-0112-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Adel" },
                    { new Guid("00000001-0001-0113-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Khadhraa" },
                    { new Guid("00000001-0001-0114-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Qahira" },
                    { new Guid("00000001-0001-0115-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Hurriyah" },
                    { new Guid("00000001-0001-0116-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Karama" },
                    { new Guid("00000001-0001-0117-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Maidan" },
                    { new Guid("00000001-0001-0118-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Shaab" },
                    { new Guid("00000001-0001-0119-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Baladiyat" },
                    { new Guid("00000001-0001-0120-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), true, false, "Al Jadriya" },
                    { new Guid("00000002-0001-0001-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Georgetown" },
                    { new Guid("00000002-0001-0002-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Capitol Hill" },
                    { new Guid("00000002-0001-0003-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Dupont Circle" },
                    { new Guid("00000002-0001-0004-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Adams Morgan" },
                    { new Guid("00000002-0001-0005-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Columbia Heights" },
                    { new Guid("00000002-0001-0006-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Navy Yard" },
                    { new Guid("00000002-0001-0007-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Foggy Bottom" },
                    { new Guid("00000002-0001-0008-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Shaw" },
                    { new Guid("00000002-0001-0009-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Brookland" },
                    { new Guid("00000002-0001-0010-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Tenleytown" },
                    { new Guid("00000002-0001-0011-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Anacostia" },
                    { new Guid("00000002-0001-0012-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Petworth" },
                    { new Guid("00000002-0001-0013-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Cleveland Park" },
                    { new Guid("00000002-0001-0014-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Woodley Park" },
                    { new Guid("00000002-0001-0015-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Mount Pleasant" },
                    { new Guid("00000002-0001-0016-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Trinidad" },
                    { new Guid("00000002-0001-0017-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Eckington" },
                    { new Guid("00000002-0001-0018-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Bloomingdale" },
                    { new Guid("00000002-0001-0019-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Kalorama" },
                    { new Guid("00000002-0001-0020-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Logan Circle" },
                    { new Guid("00000002-0001-0021-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "NoMa" },
                    { new Guid("00000002-0001-0022-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "H Street Corridor" },
                    { new Guid("00000002-0001-0023-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Southwest Waterfront" },
                    { new Guid("00000002-0001-0024-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "The Wharf" },
                    { new Guid("00000002-0001-0025-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "West End" },
                    { new Guid("00000002-0001-0026-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Glover Park" },
                    { new Guid("00000002-0001-0027-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Friendship Heights" },
                    { new Guid("00000002-0001-0028-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Brightwood" },
                    { new Guid("00000002-0001-0029-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Congress Heights" },
                    { new Guid("00000002-0001-0030-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Deanwood" },
                    { new Guid("00000002-0001-0031-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Hillcrest" },
                    { new Guid("00000002-0001-0032-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Fort Totten" },
                    { new Guid("00000002-0001-0033-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Takoma" },
                    { new Guid("00000002-0001-0034-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Michigan Park" },
                    { new Guid("00000002-0001-0035-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Bellevue" },
                    { new Guid("00000002-0001-0036-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Chevy Chase" },
                    { new Guid("00000002-0001-0037-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "North Cleveland Park" },
                    { new Guid("00000002-0001-0038-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "American University Park" },
                    { new Guid("00000002-0001-0039-0000-000000000000"), new Guid("00000002-0047-0000-0000-000000000000"), true, false, "Forest Hills" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0001-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0002-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0003-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0004-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0005-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0006-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0007-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0008-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0009-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0010-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0011-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0012-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0013-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0014-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0015-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0016-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0017-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0018-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0019-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0020-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0021-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0022-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0023-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0024-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0025-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0026-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0027-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0028-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0029-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0030-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0031-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0032-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0033-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0034-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0035-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0036-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0037-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0038-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0039-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0040-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0041-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0042-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0043-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0044-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0045-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0046-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0047-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0048-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0049-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0050-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0051-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0052-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0053-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0054-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0055-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0056-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0057-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0058-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0059-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0060-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0061-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0062-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0063-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0064-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0065-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0066-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0067-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0068-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0069-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0070-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0071-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0072-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0073-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0074-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0075-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0076-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0077-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0078-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0079-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0080-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0081-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0082-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0083-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0084-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0085-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0086-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0087-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0088-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0089-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0090-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0091-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0092-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0093-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0094-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0095-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0096-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0097-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0098-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0099-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0100-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0101-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0102-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0103-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0104-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0105-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0106-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0107-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0108-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0109-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0110-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0111-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0112-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0113-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0114-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0115-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0116-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0117-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0118-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0119-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0120-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0001-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0002-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0003-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0004-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0005-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0006-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0007-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0008-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0009-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0010-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0011-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0012-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0013-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0014-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0015-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0016-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0017-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0018-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0019-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0020-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0021-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0022-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0023-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0024-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0025-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0026-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0027-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0028-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0029-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0030-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0031-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0032-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0033-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0034-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0035-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0036-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0037-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0038-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0039-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0002-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0003-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0004-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0005-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0006-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0007-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0008-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0009-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0010-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0011-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0012-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0013-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0014-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0015-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0016-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0017-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0018-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0001-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0002-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0003-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0004-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0005-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0006-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0007-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0008-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0009-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0010-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0011-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0012-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0013-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0014-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0015-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0016-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0017-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0018-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0019-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0020-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0021-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0022-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0023-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0024-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0025-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0026-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0027-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0028-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0029-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0030-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0031-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0032-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0033-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0034-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0035-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0036-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0037-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0038-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0039-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0040-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0041-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0042-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0043-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0044-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0045-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0046-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0048-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0049-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0050-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0047-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"));

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
        }
    }
}
