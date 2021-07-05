using Infra.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Model
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string User { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [ForeignKey("Militar")]
        public int IdMilitar { get; set; }        
        public Militar Militar { get; set; }
        public UserLogin Status { get; set; }
        public List<Credential> Credentials { get; set; }
    }
}
