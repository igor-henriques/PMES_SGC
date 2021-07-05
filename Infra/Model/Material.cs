using Infra.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Infra.Model
{
    public class Material
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
