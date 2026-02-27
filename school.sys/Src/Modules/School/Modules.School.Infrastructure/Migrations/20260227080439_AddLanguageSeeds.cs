using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modules.School.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Languages",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("d0000001-0000-0000-0000-000000000001"), "en", true, false, "English" },
                    { new Guid("d0000002-0000-0000-0000-000000000002"), "ar", true, false, "Arabic" },
                    { new Guid("d0000003-0000-0000-0000-000000000003"), "fr", true, false, "French" },
                    { new Guid("d0000004-0000-0000-0000-000000000004"), "es", true, false, "Spanish" },
                    { new Guid("d0000005-0000-0000-0000-000000000005"), "zh", true, false, "Chinese (Mandarin)" },
                    { new Guid("d0000006-0000-0000-0000-000000000006"), "hi", true, false, "Hindi" },
                    { new Guid("d0000007-0000-0000-0000-000000000007"), "pt", true, false, "Portuguese" },
                    { new Guid("d0000008-0000-0000-0000-000000000008"), "bn", true, false, "Bengali" },
                    { new Guid("d0000009-0000-0000-0000-000000000009"), "ru", true, false, "Russian" },
                    { new Guid("d000000a-0000-0000-0000-00000000000a"), "ja", true, false, "Japanese" },
                    { new Guid("d000000b-0000-0000-0000-00000000000b"), "de", true, false, "German" },
                    { new Guid("d000000c-0000-0000-0000-00000000000c"), "ko", true, false, "Korean" },
                    { new Guid("d000000d-0000-0000-0000-00000000000d"), "it", true, false, "Italian" },
                    { new Guid("d000000e-0000-0000-0000-00000000000e"), "tr", true, false, "Turkish" },
                    { new Guid("d000000f-0000-0000-0000-00000000000f"), "vi", true, false, "Vietnamese" },
                    { new Guid("d0000010-0000-0000-0000-000000000010"), "fa", true, false, "Persian" },
                    { new Guid("d0000011-0000-0000-0000-000000000011"), "ur", true, false, "Urdu" },
                    { new Guid("d0000012-0000-0000-0000-000000000012"), "id", true, false, "Indonesian" },
                    { new Guid("d0000013-0000-0000-0000-000000000013"), "nl", true, false, "Dutch" },
                    { new Guid("d0000014-0000-0000-0000-000000000014"), "pl", true, false, "Polish" },
                    { new Guid("d0000015-0000-0000-0000-000000000015"), "th", true, false, "Thai" },
                    { new Guid("d0000016-0000-0000-0000-000000000016"), "el", true, false, "Greek" },
                    { new Guid("d0000017-0000-0000-0000-000000000017"), "sv", true, false, "Swedish" },
                    { new Guid("d0000018-0000-0000-0000-000000000018"), "ro", true, false, "Romanian" },
                    { new Guid("d0000019-0000-0000-0000-000000000019"), "cs", true, false, "Czech" },
                    { new Guid("d000001a-0000-0000-0000-00000000001a"), "hu", true, false, "Hungarian" },
                    { new Guid("d000001b-0000-0000-0000-00000000001b"), "he", true, false, "Hebrew" },
                    { new Guid("d000001c-0000-0000-0000-00000000001c"), "uk", true, false, "Ukrainian" },
                    { new Guid("d000001d-0000-0000-0000-00000000001d"), "ms", true, false, "Malay" },
                    { new Guid("d000001e-0000-0000-0000-00000000001e"), "sw", true, false, "Swahili" },
                    { new Guid("d000001f-0000-0000-0000-00000000001f"), "ta", true, false, "Tamil" },
                    { new Guid("d0000020-0000-0000-0000-000000000020"), "ku", true, false, "Kurdish" },
                    { new Guid("d0000021-0000-0000-0000-000000000021"), "da", true, false, "Danish" },
                    { new Guid("d0000022-0000-0000-0000-000000000022"), "no", true, false, "Norwegian" },
                    { new Guid("d0000023-0000-0000-0000-000000000023"), "fi", true, false, "Finnish" },
                    { new Guid("d0000024-0000-0000-0000-000000000024"), "sk", true, false, "Slovak" },
                    { new Guid("d0000025-0000-0000-0000-000000000025"), "bg", true, false, "Bulgarian" },
                    { new Guid("d0000026-0000-0000-0000-000000000026"), "hr", true, false, "Croatian" },
                    { new Guid("d0000027-0000-0000-0000-000000000027"), "sr", true, false, "Serbian" },
                    { new Guid("d0000028-0000-0000-0000-000000000028"), "ca", true, false, "Catalan" },
                    { new Guid("d0000029-0000-0000-0000-000000000029"), "af", true, false, "Afrikaans" },
                    { new Guid("d000002a-0000-0000-0000-00000000002a"), "ne", true, false, "Nepali" },
                    { new Guid("d000002b-0000-0000-0000-00000000002b"), "si", true, false, "Sinhala" },
                    { new Guid("d000002c-0000-0000-0000-00000000002c"), "mr", true, false, "Marathi" },
                    { new Guid("d000002d-0000-0000-0000-00000000002d"), "pa", true, false, "Punjabi" },
                    { new Guid("d000002e-0000-0000-0000-00000000002e"), "gu", true, false, "Gujarati" },
                    { new Guid("d000002f-0000-0000-0000-00000000002f"), "am", true, false, "Amharic" },
                    { new Guid("d0000030-0000-0000-0000-000000000030"), "ha", true, false, "Hausa" },
                    { new Guid("d0000031-0000-0000-0000-000000000031"), "yo", true, false, "Yoruba" },
                    { new Guid("d0000032-0000-0000-0000-000000000032"), "so", true, false, "Somali" },
                    { new Guid("d0000033-0000-0000-0000-000000000033"), "lt", true, false, "Lithuanian" },
                    { new Guid("d0000034-0000-0000-0000-000000000034"), "lv", true, false, "Latvian" },
                    { new Guid("d0000035-0000-0000-0000-000000000035"), "et", true, false, "Estonian" },
                    { new Guid("d0000036-0000-0000-0000-000000000036"), "sl", true, false, "Slovenian" },
                    { new Guid("d0000037-0000-0000-0000-000000000037"), "sq", true, false, "Albanian" },
                    { new Guid("d0000038-0000-0000-0000-000000000038"), "mk", true, false, "Macedonian" },
                    { new Guid("d0000039-0000-0000-0000-000000000039"), "hy", true, false, "Armenian" },
                    { new Guid("d000003a-0000-0000-0000-00000000003a"), "ka", true, false, "Georgian" },
                    { new Guid("d000003b-0000-0000-0000-00000000003b"), "kk", true, false, "Kazakh" },
                    { new Guid("d000003c-0000-0000-0000-00000000003c"), "uz", true, false, "Uzbek" },
                    { new Guid("d000003d-0000-0000-0000-00000000003d"), "az", true, false, "Azerbaijani" },
                    { new Guid("d000003e-0000-0000-0000-00000000003e"), "ky", true, false, "Kyrgyz" },
                    { new Guid("d000003f-0000-0000-0000-00000000003f"), "tk", true, false, "Turkmen" },
                    { new Guid("d0000040-0000-0000-0000-000000000040"), "tg", true, false, "Tajik" },
                    { new Guid("d0000041-0000-0000-0000-000000000041"), "mn", true, false, "Mongolian" },
                    { new Guid("d0000042-0000-0000-0000-000000000042"), "my", true, false, "Burmese" },
                    { new Guid("d0000043-0000-0000-0000-000000000043"), "km", true, false, "Khmer" },
                    { new Guid("d0000044-0000-0000-0000-000000000044"), "lo", true, false, "Lao" },
                    { new Guid("d0000045-0000-0000-0000-000000000045"), "tl", true, false, "Tagalog" },
                    { new Guid("d0000046-0000-0000-0000-000000000046"), "is", true, false, "Icelandic" },
                    { new Guid("d0000047-0000-0000-0000-000000000047"), "mt", true, false, "Maltese" },
                    { new Guid("d0000048-0000-0000-0000-000000000048"), "cy", true, false, "Welsh" },
                    { new Guid("d0000049-0000-0000-0000-000000000049"), "ga", true, false, "Irish" },
                    { new Guid("d000004a-0000-0000-0000-00000000004a"), "gd", true, false, "Scottish Gaelic" },
                    { new Guid("d000004b-0000-0000-0000-00000000004b"), "eu", true, false, "Basque" },
                    { new Guid("d000004c-0000-0000-0000-00000000004c"), "gl", true, false, "Galician" },
                    { new Guid("d000004d-0000-0000-0000-00000000004d"), "bs", true, false, "Bosnian" },
                    { new Guid("d000004e-0000-0000-0000-00000000004e"), "lb", true, false, "Luxembourgish" },
                    { new Guid("d000004f-0000-0000-0000-00000000004f"), "ps", true, false, "Pashto" },
                    { new Guid("d0000050-0000-0000-0000-000000000050"), "sd", true, false, "Sindhi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000002-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000003-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000004-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000005-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000006-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000007-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000008-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000009-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000000a-0000-0000-0000-00000000000a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000000b-0000-0000-0000-00000000000b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000000c-0000-0000-0000-00000000000c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000000d-0000-0000-0000-00000000000d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000000e-0000-0000-0000-00000000000e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000000f-0000-0000-0000-00000000000f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000010-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000011-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000012-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000013-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000014-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000015-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000016-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000017-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000018-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000019-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000001a-0000-0000-0000-00000000001a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000001b-0000-0000-0000-00000000001b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000001c-0000-0000-0000-00000000001c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000001d-0000-0000-0000-00000000001d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000001e-0000-0000-0000-00000000001e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000001f-0000-0000-0000-00000000001f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000020-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000021-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000022-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000023-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000024-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000025-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000026-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000027-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000028-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000029-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000002a-0000-0000-0000-00000000002a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000002b-0000-0000-0000-00000000002b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000002c-0000-0000-0000-00000000002c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000002d-0000-0000-0000-00000000002d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000002e-0000-0000-0000-00000000002e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000002f-0000-0000-0000-00000000002f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000030-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000031-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000032-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000033-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000034-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000035-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000036-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000037-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000038-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000039-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000003a-0000-0000-0000-00000000003a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000003b-0000-0000-0000-00000000003b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000003c-0000-0000-0000-00000000003c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000003d-0000-0000-0000-00000000003d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000003e-0000-0000-0000-00000000003e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000003f-0000-0000-0000-00000000003f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000040-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000041-0000-0000-0000-000000000041"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000042-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000043-0000-0000-0000-000000000043"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000044-0000-0000-0000-000000000044"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000045-0000-0000-0000-000000000045"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000046-0000-0000-0000-000000000046"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000047-0000-0000-0000-000000000047"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000048-0000-0000-0000-000000000048"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000049-0000-0000-0000-000000000049"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000004a-0000-0000-0000-00000000004a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000004b-0000-0000-0000-00000000004b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000004c-0000-0000-0000-00000000004c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000004d-0000-0000-0000-00000000004d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000004e-0000-0000-0000-00000000004e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d000004f-0000-0000-0000-00000000004f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d0000050-0000-0000-0000-000000000050"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
