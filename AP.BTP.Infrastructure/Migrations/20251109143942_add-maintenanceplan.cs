using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addmaintenanceplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaintenancePlan",
                table: "Tree",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenancePlan",
                table: "Tree");
        }
    }
}
