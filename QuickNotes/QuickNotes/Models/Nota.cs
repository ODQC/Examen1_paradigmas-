using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickNotes.Models
{
    public class Nota : Cuaderno
    {
        
        public string IdNota { get; set; }
        public string TituloNota { get; set; }
        public bool Privacidad { get; set; }
        public new string Categoria { get; set; }
        public new string Color { get; set; }
        public string Fuente { get; set; }
        public string ColorFuente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int FechaModificacion { get; set; }
        public string Texto { get; set; }
        public int Password { get; set; }
        
    }
}
