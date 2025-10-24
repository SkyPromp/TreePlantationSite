using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class zoneNameSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Zone",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Zone",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Zone");
        }
    }
}
