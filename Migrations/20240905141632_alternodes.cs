using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jus_365.Migrations
{
    /// <inheritdoc />
    public partial class alternodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "JsTreeMenuItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "JsTreeMenuItem",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon",
                table: "JsTreeMenuItem");

            migrationBuilder.DropColumn(
                name: "type",
                table: "JsTreeMenuItem");
        }
    }
}
