using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAppInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakingRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_MovieId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_MovieId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId",
                unique: true);
        }
    }
}
