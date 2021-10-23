using NoteEditor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteEditor;

namespace NoteEditor
{
    public partial class Acciones : Form
    {
        public List<Accion> HistorialUser = new List<Accion>();
        public Accion accionUsuario;
        public Acciones()
        {
            InitializeComponent();
            this.accionUsuario = new Accion();
           
        }
       public void cargarTabla(List<Accion> historialUser) {

            this.AccionesTbl.DataSource = historialUser;
        }

        private void AccionesTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Acciones_Load(object sender, EventArgs e)
        {

        }
    }
}
