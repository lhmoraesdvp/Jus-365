using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jus_365.Migrations
{
    /// <inheritdoc />
    public partial class additem_menu1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NodeItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_No = table.Column<int>(type: "int", nullable: false),
                    caminho = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Obs1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Obs2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Obs3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeItem", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NodeItem");
        }
    }
}
