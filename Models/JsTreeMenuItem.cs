using System.ComponentModel.DataAnnotations;

namespace Jus_365.Models
{
    public class JsTreeMenuItem
    {

        [Key]
        public int Id_Item { get; set; }
        public string? Id { get; set; }


        public string? ParentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? obs { get; set; }


        public string? obsInt { get; set; }
        public string? obs2 { get; set; }


        public string? obsInt2 { get; set; }
        public string? icon { get; set; }
        public string? type { get; set; }
        public string? tipo_no { get; set; }


        public bool? HasChildren { get; set; }  // Adicione esta linh
        // Outros campos que possam ser necessários
    }
}
