using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPlantationSiteUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlantationSiteUser",
                columns: new[] { "PlantationSitesId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlantationSiteUser",
                keyColumns: new[] { "PlantationSitesId", "UsersId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PlantationSiteUser",
                keyColumns: new[] { "PlantationSitesId", "UsersId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
