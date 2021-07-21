using Infra.Model.Enum;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Model
{
    public class Militar
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public Posto Posto { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }
        public int Numero { get; set; }
        [MaxLength(50)]
        public string Pelotao { get; set; }
        [MaxLength(50)]
        [Required]
        public string Funcional { get; set; }
        [Required][MaxLength(8)]
        [DefaultValue("E10ADC3949BA59ABBE56E057F20F883E")] //Hash MD5 para 123456
        public string PIN { get; set; }
        [Required]
        public Curso Curso { get; set; }
        [Required]
        [ForeignKey("Cautela")]
        public List<Cautela> Cautelas { get; set; }
    }
}