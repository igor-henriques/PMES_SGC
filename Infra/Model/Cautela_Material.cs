using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Model
{
    public class Cautela_Material
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Cautela")]
        public int Id_Cautela { get; set; }
        public Cautela Cautela { get; set; }
        [Required]
        [ForeignKey("Material")]
        public int IdMaterial { get; set; }
        public Material Material { get; set; }
        public int MaterialAmount { get; set; }
    }
}
