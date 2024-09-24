using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jus_365.Migrations
{
    /// <inheritdoc />
    public partial class addforRegisterViewModeladdSlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slot1",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot10",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot11",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot12",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot2",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot3",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot4",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot5",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot6",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot7",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot8",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slot9",
                table: "FormRegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slot1",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot10",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot11",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot12",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot2",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot3",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot4",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot5",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot6",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot7",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot8",
                table: "FormRegisterViewModel");

            migrationBuilder.DropColumn(
                name: "slot9",
                table: "FormRegisterViewModel");
        }
    }
}
