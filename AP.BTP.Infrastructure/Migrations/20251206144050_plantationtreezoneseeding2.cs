using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class plantationtreezoneseeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "Id", "IsDeleted", "Name", "PlantationSiteId", "Size", "TreeId" },
                values: new object[,]
                {
                    { 1, false, "Zone 1B", 1, 198, 31 },
                    { 2, false, "Zone 1C", 1, 246, 216 },
                    { 3, false, "Zone 2A", 1, 169, 121 },
                    { 4, false, "Zone 2B", 1, 105, 264 },
                    { 5, false, "Zone 2C", 1, 87, 180 },
                    { 6, false, "Zone 3A", 1, 160, 70 },
                    { 7, false, "Zone 1B", 2, 245, 191 },
                    { 8, false, "Zone 1C", 2, 235, 79 },
                    { 9, false, "Zone 2A", 2, 257, 197 },
                    { 10, false, "Zone 2B", 2, 103, 265 },
                    { 11, false, "Zone 2C", 2, 176, 45 },
                    { 12, false, "Zone 3A", 2, 122, 223 },
                    { 13, false, "Zone 3B", 2, 157, 222 },
                    { 14, false, "Zone 3C", 2, 304, 230 },
                    { 15, false, "Zone 4A", 2, 261, 156 },
                    { 16, false, "Zone 4B", 2, 83, 196 },
                    { 17, false, "Zone 4C", 2, 283, 277 },
                    { 18, false, "Zone 5A", 2, 95, 240 },
                    { 19, false, "Zone 5B", 2, 212, 144 },
                    { 20, false, "Zone 5C", 2, 331, 77 },
                    { 21, false, "Zone 1B", 3, 189, 108 },
                    { 22, false, "Zone 1C", 3, 251, 189 },
                    { 23, false, "Zone 2A", 3, 141, 132 },
                    { 24, false, "Zone 2B", 3, 213, 99 },
                    { 25, false, "Zone 2C", 3, 167, 48 },
                    { 26, false, "Zone 3A", 3, 179, 193 },
                    { 27, false, "Zone 3B", 3, 320, 44 },
                    { 28, false, "Zone 3C", 3, 326, 24 },
                    { 29, false, "Zone 4A", 3, 241, 137 },
                    { 30, false, "Zone 4B", 3, 110, 14 },
                    { 31, false, "Zone 4C", 3, 101, 60 },
                    { 32, false, "Zone 1B", 4, 157, 154 },
                    { 33, false, "Zone 1C", 4, 301, 279 },
                    { 34, false, "Zone 2A", 4, 135, 223 },
                    { 35, false, "Zone 2B", 4, 125, 29 },
                    { 36, false, "Zone 2C", 4, 321, 120 },
                    { 37, false, "Zone 3A", 4, 275, 113 },
                    { 38, false, "Zone 3B", 4, 111, 265 },
                    { 39, false, "Zone 1B", 5, 95, 90 },
                    { 40, false, "Zone 1C", 5, 171, 132 },
                    { 41, false, "Zone 2A", 5, 173, 108 },
                    { 42, false, "Zone 2B", 5, 236, 3 },
                    { 43, false, "Zone 2C", 5, 296, 234 },
                    { 44, false, "Zone 3A", 5, 102, 216 },
                    { 45, false, "Zone 3B", 5, 304, 8 },
                    { 46, false, "Zone 3C", 5, 300, 64 },
                    { 47, false, "Zone 4A", 5, 156, 133 },
                    { 48, false, "Zone 1B", 6, 173, 36 },
                    { 49, false, "Zone 1C", 6, 173, 133 },
                    { 50, false, "Zone 2A", 6, 157, 156 },
                    { 51, false, "Zone 2B", 6, 122, 20 },
                    { 52, false, "Zone 2C", 6, 191, 74 },
                    { 53, false, "Zone 1B", 7, 114, 49 },
                    { 54, false, "Zone 1C", 7, 331, 238 },
                    { 55, false, "Zone 2A", 7, 328, 89 },
                    { 56, false, "Zone 2B", 7, 296, 182 },
                    { 57, false, "Zone 2C", 7, 318, 196 },
                    { 58, false, "Zone 3A", 7, 254, 151 },
                    { 59, false, "Zone 3B", 7, 84, 46 },
                    { 60, false, "Zone 3C", 7, 113, 7 },
                    { 61, false, "Zone 4A", 7, 154, 21 },
                    { 62, false, "Zone 4B", 7, 101, 57 },
                    { 63, false, "Zone 4C", 7, 199, 259 },
                    { 64, false, "Zone 5A", 7, 331, 231 },
                    { 65, false, "Zone 1B", 8, 255, 237 },
                    { 66, false, "Zone 1C", 8, 93, 255 },
                    { 67, false, "Zone 2A", 8, 131, 89 },
                    { 68, false, "Zone 2B", 8, 125, 208 },
                    { 69, false, "Zone 2C", 8, 252, 24 },
                    { 70, false, "Zone 1B", 9, 87, 67 },
                    { 71, false, "Zone 1C", 9, 141, 159 },
                    { 72, false, "Zone 2A", 9, 237, 62 },
                    { 73, false, "Zone 2B", 9, 125, 168 },
                    { 74, false, "Zone 2C", 9, 252, 164 },
                    { 75, false, "Zone 3A", 9, 168, 88 },
                    { 76, false, "Zone 3B", 9, 124, 150 },
                    { 77, false, "Zone 3C", 9, 301, 278 },
                    { 78, false, "Zone 4A", 9, 170, 17 },
                    { 79, false, "Zone 4B", 9, 257, 231 },
                    { 80, false, "Zone 1B", 10, 301, 239 },
                    { 81, false, "Zone 1C", 10, 153, 132 },
                    { 82, false, "Zone 2A", 10, 282, 207 },
                    { 83, false, "Zone 2B", 10, 267, 107 },
                    { 84, false, "Zone 2C", 10, 208, 223 },
                    { 85, false, "Zone 3A", 10, 165, 22 },
                    { 86, false, "Zone 3B", 10, 306, 108 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 86);
        }
    }
}
