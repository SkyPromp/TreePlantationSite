using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPlantationSiteToTaskList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskList",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskList",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "PlantationSiteId",
                table: "TaskList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_PlantationSiteId",
                table: "TaskList",
                column: "PlantationSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_PlantationSite_PlantationSiteId",
                table: "TaskList",
                column: "PlantationSiteId",
                principalTable: "PlantationSite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_PlantationSite_PlantationSiteId",
                table: "TaskList");

            migrationBuilder.DropIndex(
                name: "IX_TaskList_PlantationSiteId",
                table: "TaskList");

            migrationBuilder.DropColumn(
                name: "PlantationSiteId",
                table: "TaskList");

            migrationBuilder.InsertData(
                table: "TaskList",
                columns: new[] { "Id", "Date", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 },
                    { 2, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 },
                    { 3, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 }
                });

            migrationBuilder.InsertData(
                table: "TaskItem",
                columns: new[] { "Id", "Description", "IsDeleted", "TaskListId", "Title" },
                values: new object[,]
                {
                    { 1, "Description 1", false, 1, "Task 1" },
                    { 2, "Description 2", false, 1, "Task 2" },
                    { 3, "Description 3", false, 2, "Task 3" }
                });
        }
    }
}
