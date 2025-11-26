using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.BTP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserApprovalAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlantationSiteUser",
                keyColumns: new[] { "PlantationSitesId", "UsersId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PlantationSiteUser",
                keyColumns: new[] { "PlantationSitesId", "UsersId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Auth0Id", "Email", "FirstName", "IsApproved", "LastName", "PhoneNumber", "Role" },
                values: new object[] { "auth0|68f5f3c8fa9e243c35508427", "admin123@admin.admin", "Admin1", true, "Lastname", "0123456789", "Admin" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Auth0Id", "Email", "FirstName", "IsApproved", "LastName", "PhoneNumber", "Role" },
                values: new object[] { "auth0|690db2550eb8c001baeaeb22", "manager123@manager.manager", "Manager1", true, "Lastname", "0123456789", "Manager" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Auth0Id", "Email", "FirstName", "IsApproved", "IsDeleted", "LastName", "PhoneNumber", "Role" },
                values: new object[] { 3, "auth0|68f7f831f5bc833fc99fca15", "operator123@operator.operator", "Operator1", true, false, "Lastname", "0123456789", "Operator" });

            migrationBuilder.InsertData(
                table: "PlantationSiteUser",
                columns: new[] { "PlantationSitesId", "UsersId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlantationSiteUser",
                keyColumns: new[] { "PlantationSitesId", "UsersId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PlantationSiteUser",
                keyColumns: new[] { "PlantationSitesId", "UsersId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.InsertData(
                table: "PlantationSiteUser",
                columns: new[] { "PlantationSitesId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Auth0Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "auth0|user1", "alice@example.com", "Alice", "", "" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Auth0Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "auth0|user2", "bob@example.com", "Bob", "", "" });
        }
    }
}
