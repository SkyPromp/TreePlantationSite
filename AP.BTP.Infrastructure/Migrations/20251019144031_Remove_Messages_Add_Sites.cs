using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Messages_Add_Sites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.CreateTable(
                name: "PlantationSite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroundPlan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationSite", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PlantationSite",
                columns: new[] { "Id", "City", "Country", "GroundPlan", "HouseNumber", "Name", "PostalCode", "Street" },
                values: new object[,]
                {
                    { -11, "City Site 10", "Belgium", "Groundplan Site 10", 10, "Site 10", 1010, "Street Site 10" },
                    { -10, "City Site 9", "Belgium", "Groundplan Site 9", 9, "Site 9", 1009, "Street Site 9" },
                    { -9, "City Site 8", "Belgium", "Groundplan Site 8", 8, "Site 8", 1008, "Street Site 8" },
                    { -8, "City Site 7", "Belgium", "Groundplan Site 7", 7, "Site 7", 1007, "Street Site 7" },
                    { -7, "City Site 6", "Belgium", "Groundplan Site 6", 6, "Site 6", 1006, "Street Site 6" },
                    { -6, "City Site 5", "Belgium", "Groundplan Site 5", 5, "Site 5", 1005, "Street Site 5" },
                    { -5, "City Site 4", "Belgium", "Groundplan Site 4", 4, "Site 4", 1004, "Street Site 4" },
                    { -4, "City Site 3", "Belgium", "Groundplan Site 3", 3, "Site 3", 1003, "Street Site 3" },
                    { -3, "City Site 2", "Belgium", "Groundplan Site 2", 2, "Site 2", 1002, "Street Site 2" },
                    { -2, "City Site 1", "Belgium", "Groundplan Site 1", 1, "Site 1", 1001, "Street Site 1" },
                    { -1, "City Site 0", "Belgium", "Groundplan Site 0", 0, "Site 0", 1000, "Street Site 0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantationSite");

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { -2, "Works" },
                    { -1, "Banana" }
                });
        }
    }
}
