using System.ComponentModel.DataAnnotations;

namespace Jus_365.Models
{
    public class FormularioLogin
    {



        [Key]
        public int Id { get; set; } // Chave primária

        [Required]
        public string key { get; set; } // Chave primária

        [Required]
        public string nome { get; set; } // Chave primária

        [StringLength(150)]
        public string? slot1 { get; set; }
        [StringLength(150)]
        public string? slot2 { get; set; }
        [StringLength(150)]
        public string? slot3 { get; set; }
        [StringLength(150)]
        public string? slot4 { get; set; }
        [StringLength(150)]
        public string? slot5 { get; set; }
        [StringLength(150)]
        public string? slot6 { get; set; }
        [StringLength(150)]
        public string? slot7 { get; set; }
        [StringLength(150)]
        public string? slot8 { get; set; }
        [StringLength(150)]
        public string? slot9 { get; set; }

    }
}
