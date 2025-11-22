using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTreePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreePicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TreeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreePicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreePicture_Tree_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Tree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tree",
                columns: new[] { "Id", "IsDeleted", "MaintenancePlan", "Species" },
                values: new object[,]
                {
                    { 1, false, "Maintenance plan 1", "Tree 1" },
                    { 2, false, "Maintenance plan 2", "Tree 2" },
                    { 3, false, "Maintenance plan 3", "Tree 3" },
                    { 4, false, "Maintenance plan 4", "Tree 4" },
                    { 5, false, "Maintenance plan 5", "Tree 5" },
                    { 6, false, "Maintenance plan 6", "Tree 6" },
                    { 7, false, "Maintenance plan 7", "Tree 7" },
                    { 8, false, "Maintenance plan 8", "Tree 8" },
                    { 9, false, "Maintenance plan 9", "Tree 9" },
                    { 10, false, "Maintenance plan 10", "Tree 10" },
                    { 11, false, "Maintenance plan 11", "Tree 11" },
                    { 12, false, "Maintenance plan 12", "Tree 12" },
                    { 13, false, "Maintenance plan 13", "Tree 13" },
                    { 14, false, "Maintenance plan 14", "Tree 14" },
                    { 15, false, "Maintenance plan 15", "Tree 15" },
                    { 16, false, "Maintenance plan 16", "Tree 16" },
                    { 17, false, "Maintenance plan 17", "Tree 17" },
                    { 18, false, "Maintenance plan 18", "Tree 18" },
                    { 19, false, "Maintenance plan 19", "Tree 19" },
                    { 20, false, "Maintenance plan 20", "Tree 20" },
                    { 21, false, "Maintenance plan 21", "Tree 21" },
                    { 22, false, "Maintenance plan 22", "Tree 22" },
                    { 23, false, "Maintenance plan 23", "Tree 23" },
                    { 24, false, "Maintenance plan 24", "Tree 24" },
                    { 25, false, "Maintenance plan 25", "Tree 25" },
                    { 26, false, "Maintenance plan 26", "Tree 26" },
                    { 27, false, "Maintenance plan 27", "Tree 27" },
                    { 28, false, "Maintenance plan 28", "Tree 28" },
                    { 29, false, "Maintenance plan 29", "Tree 29" },
                    { 30, false, "Maintenance plan 30", "Tree 30" },
                    { 31, false, "Maintenance plan 31", "Tree 31" },
                    { 32, false, "Maintenance plan 32", "Tree 32" },
                    { 33, false, "Maintenance plan 33", "Tree 33" },
                    { 34, false, "Maintenance plan 34", "Tree 34" },
                    { 35, false, "Maintenance plan 35", "Tree 35" },
                    { 36, false, "Maintenance plan 36", "Tree 36" },
                    { 37, false, "Maintenance plan 37", "Tree 37" },
                    { 38, false, "Maintenance plan 38", "Tree 38" },
                    { 39, false, "Maintenance plan 39", "Tree 39" },
                    { 40, false, "Maintenance plan 40", "Tree 40" },
                    { 41, false, "Maintenance plan 41", "Tree 41" },
                    { 42, false, "Maintenance plan 42", "Tree 42" },
                    { 43, false, "Maintenance plan 43", "Tree 43" },
                    { 44, false, "Maintenance plan 44", "Tree 44" },
                    { 45, false, "Maintenance plan 45", "Tree 45" },
                    { 46, false, "Maintenance plan 46", "Tree 46" },
                    { 47, false, "Maintenance plan 47", "Tree 47" },
                    { 48, false, "Maintenance plan 48", "Tree 48" },
                    { 49, false, "Maintenance plan 49", "Tree 49" },
                    { 50, false, "Maintenance plan 50", "Tree 50" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreePicture_TreeId",
                table: "TreePicture",
                column: "TreeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreePicture");

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
