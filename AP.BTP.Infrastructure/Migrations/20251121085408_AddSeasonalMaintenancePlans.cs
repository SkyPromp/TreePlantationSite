using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeasonalMaintenancePlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaintenancePlan",
                table: "Tree",
                newName: "MaintenancePlanWinter");

            migrationBuilder.AddColumn<string>(
                name: "MaintenancePlanAutumn",
                table: "Tree",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaintenancePlanSpring",
                table: "Tree",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaintenancePlanSummer",
                table: "Tree",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenancePlanAutumn",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "MaintenancePlanSpring",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "MaintenancePlanSummer",
                table: "Tree");

            migrationBuilder.RenameColumn(
                name: "MaintenancePlanWinter",
                table: "Tree",
                newName: "MaintenancePlan");
        }
    }
}
