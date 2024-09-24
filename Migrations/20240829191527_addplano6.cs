﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jus_365.Migrations
{
    /// <inheritdoc />
    public partial class addplano6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Obs1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Obs2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Obs3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plano_RoleViewModel_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plano_RoleId",
                table: "Plano",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plano");

            migrationBuilder.DropTable(
                name: "RoleViewModel");
        }
    }
}
