using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jus_365.Migrations
{
    /// <inheritdoc />
    public partial class addforRegisterViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormRegisterViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneResidencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutroTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataExpedicaoRG = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrgaoExpedicaoRG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataValidadeCNH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoExpedidorCNH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Planos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arquivo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arquivo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arquivo3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arquivo4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arquivo5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPFCNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEPEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CidadeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogradouroEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplementoEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormRegisterViewModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
        }
    }
}
