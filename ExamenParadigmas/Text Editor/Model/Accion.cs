using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteEditor.Model
{
    public class Accion
    {
        public Accion(string idAccion, string descripcion)
        {
            IdAccion = idAccion;
            Descripcion = descripcion;
            FechaAccion = DateTime.Now;
        }
        public Accion()
        {
            IdAccion = "";
            Descripcion = "";
            FechaAccion = DateTime.Now;
        }

        public string  IdAccion { get; set; }
        public string Descripcion  { get; set; }
        public DateTime FechaAccion { get; set; }


    }
}
