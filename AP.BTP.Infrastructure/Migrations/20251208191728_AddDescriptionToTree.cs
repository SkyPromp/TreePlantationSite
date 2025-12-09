using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToTree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tree",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 1 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 2 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 3 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 4 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 5 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 6 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 7 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 8 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 9 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 10 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 11 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 12 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 13 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 14 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 15 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 16,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 16 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 17 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 18,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 18 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 19 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 20 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 21 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 22 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 23 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 24,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 24 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 25,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 25 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 26 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 27 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 28 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 29,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 29 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 30,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 30 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 31,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 31 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 32,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 32 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 33,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 33 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 34,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 34 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 35,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 35 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 36,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 36 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 37,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 37 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 38,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 38 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 39,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 39 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 40,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 40 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 41,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 41 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 42,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 42 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 43,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 43 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 44,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 44 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 45,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 45 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 46,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 46 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 47,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 47 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 48,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 48 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 49,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 49 is and all kinds of details");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 50,
                column: "Description",
                value: "Very detailed tree description explaining what tree number 50 is and all kinds of details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tree");
        }
    }
}
