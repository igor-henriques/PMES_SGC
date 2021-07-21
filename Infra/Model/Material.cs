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
        public int Count { get; set; }
        public bool IsUnique { get; set; }

        public static Material Clone(Material source)
        {
            return new Material
            {
                Nome = source.Nome,
                Code = source.Code,
                Count = source.Count,
                IsUnique = source.IsUnique
            };
        }
    }
}
