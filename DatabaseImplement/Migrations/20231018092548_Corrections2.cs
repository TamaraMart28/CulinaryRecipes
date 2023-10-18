using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class Corrections2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "Users");
        }
    }
}
