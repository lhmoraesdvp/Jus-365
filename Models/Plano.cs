using System.ComponentModel.DataAnnotations;

namespace Jus_365.Models
{
    public class Plano
    {



        [Key]
        public int Id { get; set; } // Chave primária

        [Required]
        [StringLength(100)]
        public string Description { get; set; } // Descrição do plano

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } // Preço do plano

        [StringLength(500)]
        public string Obs1 { get; set; } // Observações
        [StringLength(500)]
        public string Obs2 { get; set; } // Observações
        [StringLength(500)]
        public string Obs3 { get; set; } // Observações

    
        public RoleViewModel Role { get; set; } // Código do plano
    }


}

