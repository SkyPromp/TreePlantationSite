using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlantationSiteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "PlantationSite",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlantationSite",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "1A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "2A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "3A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "4A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "5A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "6A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "7A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "8A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "9A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "10A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "11A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "12A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "13A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "14A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "15A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "16A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "17A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "18A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "19A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "20A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "21A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "22A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "23A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "24A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "25A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "26A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "27A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "28A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "29A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "30A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "31A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "32A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "33A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "34A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "35A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "36A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "37A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "38A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "39A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "40A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "41A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "42A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "43A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "44A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "45A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "46A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "47A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "48A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "49A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "50A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "51A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "52A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "53A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "54A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "55A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "56A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "57A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "58A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "59A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "60A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "61A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "62A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "63A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "64A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "65A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "66A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "67A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "68A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "69A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "70A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "71A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "72A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "73A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "74A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "75A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "76A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "77A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "78A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "79A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "80A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "81A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "82A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "83A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "84A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "85A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "86A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "87A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "88A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "89A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "90A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "91A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "92A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "93A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "94A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "95A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "96A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "97A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "98A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "99A", false });

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "HouseNumber", "IsDeleted" },
                values: new object[] { "100A", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlantationSite");

            migrationBuilder.AlterColumn<int>(
                name: "HouseNumber",
                table: "PlantationSite",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 1,
                column: "HouseNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 2,
                column: "HouseNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 3,
                column: "HouseNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 4,
                column: "HouseNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 5,
                column: "HouseNumber",
                value: 5);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 6,
                column: "HouseNumber",
                value: 6);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 7,
                column: "HouseNumber",
                value: 7);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 8,
                column: "HouseNumber",
                value: 8);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 9,
                column: "HouseNumber",
                value: 9);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 10,
                column: "HouseNumber",
                value: 10);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 11,
                column: "HouseNumber",
                value: 11);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 12,
                column: "HouseNumber",
                value: 12);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 13,
                column: "HouseNumber",
                value: 13);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 14,
                column: "HouseNumber",
                value: 14);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 15,
                column: "HouseNumber",
                value: 15);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 16,
                column: "HouseNumber",
                value: 16);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 17,
                column: "HouseNumber",
                value: 17);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 18,
                column: "HouseNumber",
                value: 18);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 19,
                column: "HouseNumber",
                value: 19);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 20,
                column: "HouseNumber",
                value: 20);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 21,
                column: "HouseNumber",
                value: 21);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 22,
                column: "HouseNumber",
                value: 22);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 23,
                column: "HouseNumber",
                value: 23);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 24,
                column: "HouseNumber",
                value: 24);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 25,
                column: "HouseNumber",
                value: 25);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 26,
                column: "HouseNumber",
                value: 26);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 27,
                column: "HouseNumber",
                value: 27);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 28,
                column: "HouseNumber",
                value: 28);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 29,
                column: "HouseNumber",
                value: 29);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 30,
                column: "HouseNumber",
                value: 30);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 31,
                column: "HouseNumber",
                value: 31);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 32,
                column: "HouseNumber",
                value: 32);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 33,
                column: "HouseNumber",
                value: 33);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 34,
                column: "HouseNumber",
                value: 34);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 35,
                column: "HouseNumber",
                value: 35);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 36,
                column: "HouseNumber",
                value: 36);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 37,
                column: "HouseNumber",
                value: 37);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 38,
                column: "HouseNumber",
                value: 38);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 39,
                column: "HouseNumber",
                value: 39);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 40,
                column: "HouseNumber",
                value: 40);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 41,
                column: "HouseNumber",
                value: 41);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 42,
                column: "HouseNumber",
                value: 42);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 43,
                column: "HouseNumber",
                value: 43);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 44,
                column: "HouseNumber",
                value: 44);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 45,
                column: "HouseNumber",
                value: 45);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 46,
                column: "HouseNumber",
                value: 46);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 47,
                column: "HouseNumber",
                value: 47);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 48,
                column: "HouseNumber",
                value: 48);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 49,
                column: "HouseNumber",
                value: 49);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 50,
                column: "HouseNumber",
                value: 50);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 51,
                column: "HouseNumber",
                value: 51);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 52,
                column: "HouseNumber",
                value: 52);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 53,
                column: "HouseNumber",
                value: 53);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 54,
                column: "HouseNumber",
                value: 54);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 55,
                column: "HouseNumber",
                value: 55);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 56,
                column: "HouseNumber",
                value: 56);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 57,
                column: "HouseNumber",
                value: 57);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 58,
                column: "HouseNumber",
                value: 58);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 59,
                column: "HouseNumber",
                value: 59);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 60,
                column: "HouseNumber",
                value: 60);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 61,
                column: "HouseNumber",
                value: 61);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 62,
                column: "HouseNumber",
                value: 62);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 63,
                column: "HouseNumber",
                value: 63);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 64,
                column: "HouseNumber",
                value: 64);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 65,
                column: "HouseNumber",
                value: 65);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 66,
                column: "HouseNumber",
                value: 66);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 67,
                column: "HouseNumber",
                value: 67);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 68,
                column: "HouseNumber",
                value: 68);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 69,
                column: "HouseNumber",
                value: 69);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 70,
                column: "HouseNumber",
                value: 70);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 71,
                column: "HouseNumber",
                value: 71);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 72,
                column: "HouseNumber",
                value: 72);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 73,
                column: "HouseNumber",
                value: 73);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 74,
                column: "HouseNumber",
                value: 74);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 75,
                column: "HouseNumber",
                value: 75);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 76,
                column: "HouseNumber",
                value: 76);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 77,
                column: "HouseNumber",
                value: 77);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 78,
                column: "HouseNumber",
                value: 78);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 79,
                column: "HouseNumber",
                value: 79);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 80,
                column: "HouseNumber",
                value: 80);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 81,
                column: "HouseNumber",
                value: 81);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 82,
                column: "HouseNumber",
                value: 82);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 83,
                column: "HouseNumber",
                value: 83);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 84,
                column: "HouseNumber",
                value: 84);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 85,
                column: "HouseNumber",
                value: 85);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 86,
                column: "HouseNumber",
                value: 86);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 87,
                column: "HouseNumber",
                value: 87);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 88,
                column: "HouseNumber",
                value: 88);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 89,
                column: "HouseNumber",
                value: 89);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 90,
                column: "HouseNumber",
                value: 90);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 91,
                column: "HouseNumber",
                value: 91);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 92,
                column: "HouseNumber",
                value: 92);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 93,
                column: "HouseNumber",
                value: 93);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 94,
                column: "HouseNumber",
                value: 94);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 95,
                column: "HouseNumber",
                value: 95);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 96,
                column: "HouseNumber",
                value: 96);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 97,
                column: "HouseNumber",
                value: 97);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 98,
                column: "HouseNumber",
                value: 98);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 99,
                column: "HouseNumber",
                value: 99);

            migrationBuilder.UpdateData(
                table: "PlantationSite",
                keyColumn: "Id",
                keyValue: 100,
                column: "HouseNumber",
                value: 100);
        }
    }
}
