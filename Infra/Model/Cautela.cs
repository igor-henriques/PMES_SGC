using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Model
{
    public class Cautela
    {
        [Key]
        public int Id { get; set; }        
        [Required]
        [ForeignKey("Militar")]
        public int IdMilitar { get; set; }
        public Militar Militar { get; set; }
        [Required]
        public DateTime DataRetirada { get; set; }
        [Required]
        public DateTime DataDevolucao { get; set; }        
        public List<Material> Materiais { get; set; }
        public string Observations { get; set; }
    }
}
