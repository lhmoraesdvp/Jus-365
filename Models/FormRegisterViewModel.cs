using System.ComponentModel.DataAnnotations;

namespace Jus_365.Models
{
    public class FormRegisterViewModel
    {

        // Chave Primária
        [Key]
        public int Id { get; set; }

        // Dados Pessoais
        [StringLength(100)]
        public string? NomeCompleto { get; set; }

        public string? Sexo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        // Contato
        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? TelefoneCelular { get; set; }

        [Phone]
        public string? TelefoneResidencial { get; set; }

        [Phone]
        public string? OutroTelefone { get; set; }

        // Endereço Pessoal
        public string? CEP { get; set; }

        public string? Estado { get; set; }

        public string? Cidade { get; set; }

        public string? Logradouro { get; set; }

        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        // Documentos Pessoais
        public string? CPF { get; set; }

        public string? RG { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataExpedicaoRG { get; set; }

        public string? OrgaoExpedicaoRG { get; set; }

        public string? CNH { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataValidadeCNH { get; set; }

        public string? EstadoExpedidorCNH { get; set; }

        // Plano
        public string? Planos { get; set; }

        // Arquivos
        public string? Arquivo1 { get; set; }

        public string? Arquivo2 { get; set; }

        public string? Arquivo3 { get; set; }

        public string? Arquivo4 { get; set; }

        public string? Arquivo5 { get; set; }

        // Empresa
        public string? CPFCNPJ { get; set; }

        public string? RazaoSocial { get; set; }

        public string? InscricaoEstadual { get; set; }

        [Phone]
        public string? TelefoneEmpresa { get; set; }

        [EmailAddress]
        public string? EmailEmpresa { get; set; }

        public string? InscricaoMunicipal { get; set; }

        public string? Certificado { get; set; }

        // Endereço Empresarial
        public string? CEPEmpresa { get; set; }

        public string? EstadoEmpresa { get; set; }

        public string? CidadeEmpresa { get; set; }

        public string? LogradouroEmpresa { get; set; }

        public string? NumeroEmpresa { get; set; }

        public string? ComplementoEmpresa { get; set; }

        // Login
        [EmailAddress]
        public string? LoginEmail { get; set; }

        [DataType(DataType.Password)]
        public string? Senha { get; set; }


        public string? slot1 { get; set; }
        public string? slot2 { get; set; }

        public string? slot3 { get; set; }

        public string? slot4 { get; set; }

        public string? slot5 { get; set; }

        public string? slot6 { get; set; }

        public string? slot7 { get; set; }

        public string? slot8 { get; set; }

        public string? slot9 { get; set; }

        public string? slot10 { get; set; }
        public string? slot11 { get; set; }

        public string? slot12 { get; set; }


    }
}
