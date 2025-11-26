using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddZoneToTaskListRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "TaskList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_ZoneId",
                table: "TaskList",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_Zone_ZoneId",
                table: "TaskList",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_Zone_ZoneId",
                table: "TaskList");

            migrationBuilder.DropIndex(
                name: "IX_TaskList_ZoneId",
                table: "TaskList");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "TaskList");
        }
    }
}
