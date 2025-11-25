using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddZoneToTaskItemRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "TaskItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_ZoneId",
                table: "TaskItem",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_Zone_ZoneId",
                table: "TaskItem",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_Zone_ZoneId",
                table: "TaskItem");

            migrationBuilder.DropIndex(
                name: "IX_TaskItem_ZoneId",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "TaskItem");
        }
    }
}
