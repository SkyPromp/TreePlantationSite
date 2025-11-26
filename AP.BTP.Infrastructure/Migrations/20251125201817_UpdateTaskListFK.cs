using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaskListFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_PlantationSite_PlantationSiteId",
                table: "TaskList");

            migrationBuilder.AlterColumn<int>(
                name: "PlantationSiteId",
                table: "TaskList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_PlantationSite_PlantationSiteId",
                table: "TaskList",
                column: "PlantationSiteId",
                principalTable: "PlantationSite",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_PlantationSite_PlantationSiteId",
                table: "TaskList");

            migrationBuilder.AlterColumn<int>(
                name: "PlantationSiteId",
                table: "TaskList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_PlantationSite_PlantationSiteId",
                table: "TaskList",
                column: "PlantationSiteId",
                principalTable: "PlantationSite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
