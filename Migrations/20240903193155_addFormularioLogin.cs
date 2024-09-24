using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jus_365.Migrations
{
    /// <inheritdoc />
    public partial class addFormularioLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormularioLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slot1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    slot2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    slot3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    slot4 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    slot5 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    slot6 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    slot7 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    slot8 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    slot9 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioLogin", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormularioLogin");
        }
    }
}
