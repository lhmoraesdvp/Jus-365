using System.ComponentModel.DataAnnotations;

namespace Jus_365.Models
{
    public class Empresa
    {


        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Nome da Empresa")]
        public string Razao_Social { get; set; }
        public string Nome_Fantasia { get; set; }


      
        [StringLength(14, MinimumLength = 14)]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [StringLength(11, MinimumLength = 11)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [StringLength(20)]
        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [StringLength(20)]
        [Display(Name = "Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Phone]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [EmailAddress]
        [Display(Name = "Email Administrador")]
        public string Email_Admin { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime? Data_Cadastro { get; set; } = System.DateTime.Now;

        [Display(Name = "Ativo")]
        public Boolean? Ativo { get; set; } 
    }


}

