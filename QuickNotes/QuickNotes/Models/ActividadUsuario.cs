using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickNotes.Models
{
    public class ActividadUsuario
    {
        [Key]
        public int IdActividad { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime  FechaIncidencia { get; set; }
    }
}
