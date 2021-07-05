using Infra.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infra.Model
{
    public class Usuario_Credential
    {
        public int Id { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public Credential Credential { get; set; }
    }
}
