using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickNotes.Models
{
   
    public class Cuaderno
        {
           
            [Key]
            public int IdCuarderno { get; set; }
            public string NombreCuaderno { get; set; }
            public string Categoria { get; set; }
            public string Color { get; set; }
            public string Orden { get; set; }
            public Usuario Usuario { get; set; }
            
        }
    
}
