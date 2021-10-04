    using System;
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
    using System.Threading.Tasks;

namespace QuickNotes.Models
{
    public class Usuario
    {

        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Activadad { get; set; }
        public string TipoUsuario { get; set; }
        public List<Usuario> UserList { get; set; }

    }
}
