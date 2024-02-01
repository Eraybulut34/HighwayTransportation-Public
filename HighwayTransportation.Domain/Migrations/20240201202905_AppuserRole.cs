using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighwayTransportation.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AppuserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AppUsers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AppUsers");
        }
    }
}
