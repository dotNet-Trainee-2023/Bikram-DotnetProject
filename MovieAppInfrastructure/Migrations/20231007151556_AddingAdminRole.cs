using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAppInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "PasswordHash", "Role", "UserName" },
                values: new object[] { 1, "stha.bikram999@gmail.com", "Bikram", "Stha", "$2a$11$VBXS0oug0JmrE3RZfPRaXuhMTufJJRMgdeMCgBkNpNxczcavrJeTy", "Admin", "BikramShrestha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
