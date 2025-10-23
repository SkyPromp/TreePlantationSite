using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class zone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantationSiteId = table.Column<int>(type: "int", nullable: false),
                    TreeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zone_PlantationSite_PlantationSiteId",
                        column: x => x.PlantationSiteId,
                        principalTable: "PlantationSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zone_Tree_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Tree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zone_PlantationSiteId",
                table: "Zone",
                column: "PlantationSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_TreeId",
                table: "Zone",
                column: "TreeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
