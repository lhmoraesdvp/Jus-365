using System.ComponentModel.DataAnnotations;

namespace Jus_365.Models
{
    public class NodeItem
    {


        [Key]
        public int Id { get; set; } // Chave primária

        [Required]
        public int Id_No { get; set; } // Chave primária


        [Required]
        [StringLength(1000)]
        public string caminho { get; set; }


        [StringLength(500)]
        public string Obs1 { get; set; } // Observações
        [StringLength(500)]
        public string Obs2 { get; set; } // Observações
        [StringLength(500)]
        public string Obs3 { get; set; } // Observações

    }
}
