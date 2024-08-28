using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jus_365.Migrations
{
    /// <inheritdoc />
    public partial class addJstreeMenuItem1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "JsTreeMenuItem",
                columns: table => new
                {
                    Id_Item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obsInt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obsInt2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasChildren = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JsTreeMenuItem", x => x.Id_Item);
                });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
