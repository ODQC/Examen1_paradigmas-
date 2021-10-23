using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteEditor.Model;

namespace NoteEditor.Controller
{
   
    public class NoteEditorController
    {
        // Lista de constantes de acciones
        public const string Accion1 = "El usuario cotó el texto";
        public const string Accion2 = "El usuario pegó el texto";
        public const string Accion3 = "El usuario guardó el texto";
        public const string Accion4 = "El usuario se devolvío a la acción anterior";
        public const string Accion5 = "El usuario se devolvío a la acción suiguiente";
        public const string Accion6 = "El usuario copió el texto";
        public const string Accion7 = "El usuario eliminó el texto";
        //Variables estaticas
        public static int contador;
        public static int limite;
        //Vistas
        private TextEditor noteEditorView = new TextEditor();
        private Acciones AccionesView;
        //Modelos
        private Note NoteModel;
        private Accion accionUsuario;
        List<Accion> historialUser = new List<Accion>();
        //Otras variables globales
        List<string> colorList = new List<string>();  
        string filenamee;    
        const int MIDDLE = 382;   
        int sumRGB;
        // int pos, line, column;    
        string direccionAutoSave;

        public NoteEditorController(TextEditor noteEditorView) {

            contador = 0;
            limite = 5;
            this.noteEditorView = noteEditorView;
            this.noteEditorView.lbLimite.Text = limite.ToString();
            this.CararEventos();
            Application.Run(this.noteEditorView);
        }
        void CararEventos()// funcion que crea los eventos de listener de cada elemento de la vista
        {
         this.noteEditorView.verHistorialMenuItem.Click += new System.EventHandler(this.motrarHistorial);
            this.noteEditorView.tipoLetraBtn.SelectedIndexChanged += new System.EventHandler(this.cambiarTipoLetra);
            this.noteEditorView.tamanioLetraSlc.Click += new System.EventHandler(this.cambiarTamanioTexto);
            this.noteEditorView.tamanioLetraSlc.SelectedIndexChanged += new System.EventHandler(this.cambiarTamanioTexto);
            this.noteEditorView.colorBnt.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.colorTexto);
            this.noteEditorView.lowercaseToolStripMenuItem.Click += new System.EventHandler(this.textoMinuscula);
            this.noteEditorView.uppercaseToolStripMenuItem.Click += new System.EventHandler(this.textoMayuscula);
            this.noteEditorView.subrayadoBtn.Click += new System.EventHandler(this.underlineStripButton_Click);
            this.noteEditorView.negritaBtn.Click += new System.EventHandler(this.boldStripButton3_Click);
            this.noteEditorView.imprimirBtn.Click += new System.EventHandler(this.printStripButton_Click);
            this.noteEditorView.cuadroTexto.DragDrop += new System.Windows.Forms.DragEventHandler(this.richTextBox1_DragDrop);
            this.noteEditorView.cuadroTexto.DragEnter += new System.Windows.Forms.DragEventHandler(this.richTextBox1_DragEnter);
            this.noteEditorView.cuadroTexto.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.noteEditorView.Load += new EventHandler(this.cargarEditor);
            this.noteEditorView.cuadroTexto.KeyUp += new KeyEventHandler(disparadorAcciones);
            this.noteEditorView.vistaPreviaBtn.Click += new EventHandler(vistaPrevia);
            this.noteEditorView.guardarBtn.Click += new EventHandler(guardar);
            this.noteEditorView.imagenA.Click += new EventHandler(insertarImagen);
            this.noteEditorView.abrirBtn.Click += new EventHandler(abrirArchivo);
            this.noteEditorView.tipoLetraBtn.Click += new EventHandler(cambiarTipoLetra);
            this.noteEditorView.tamanioLetraSlc.Click += new EventHandler(cambiarTamanioTexto);
            this.noteEditorView.alinearIzquierdaBtn.Click += new EventHandler(alinearTextoIzquierda);
            this.noteEditorView.centrarTextoBtn.Click += new EventHandler(centrarTexto);
            this.noteEditorView.alinearDerechaBtn.Click += new EventHandler(alinearTextoDerecha);
            this.noteEditorView.EnlistarBtn.Click += new EventHandler(enlistarTexto); //con puntos
            this.noteEditorView.atrasBtn.Click += new EventHandler(anterior);
            this.noteEditorView.siguienteBtn.Click += new EventHandler(siguiente);
            this.noteEditorView.timer1.Tick += new EventHandler(autoGuardado);
        }
        private void cargarEditor(object sender, EventArgs e)
        {
            this.noteEditorView.cuadroTexto.AllowDrop = true;     
            this.noteEditorView.cuadroTexto.AcceptsTab = true;   
            this.noteEditorView.cuadroTexto.WordWrap = false;    
            this.noteEditorView.cuadroTexto.ShortcutsEnabled = false;    
            this.noteEditorView.cuadroTexto.DetectUrls = true;    
            this.noteEditorView.alinearIzquierdaBtn.Checked = true;
            this.noteEditorView.centrarTextoBtn.Checked = false;
            this.noteEditorView.alinearDerechaBtn.Checked = false;
            this.noteEditorView.negritaBtn.Checked = false;
            this.noteEditorView.italicabtn.Checked = false;
            this.noteEditorView.alinearDerechaBtn.Checked = false;
            this.noteEditorView.EnlistarBtn.Checked = false;
            this.noteEditorView.MinimizeBox = false;
            this.noteEditorView.MaximizeBox = false;
            this.noteEditorView.FormBorderStyle = FormBorderStyle.FixedSingle;
      
            for (int i = 8; i < 80; i += 2)
            {
                this.noteEditorView.tamanioLetraSlc.Items.Add(i);
            }

            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                {
                    colorList.Add(prop.Name);
                }
            }

      
            foreach (string color in colorList)
            {
                this.noteEditorView.colorBnt.DropDownItems.Add(color);
            }

            
            for (int i = 0; i < this.noteEditorView.colorBnt.DropDownItems.Count; i++)
            {
                
                KnownColor selectedColor;
                selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), colorList[i]);    
                this.noteEditorView.colorBnt.DropDownItems[i].BackColor = Color.FromKnownColor(selectedColor);  

              
                Color col = Color.FromName(colorList[i]);

               
                sumRGB = ConvertToRGB(col); 
                if (sumRGB <= MIDDLE)    
                {
                    this.noteEditorView.colorBnt.DropDownItems[i].ForeColor = Color.White;   
                }
                else if (sumRGB > MIDDLE)  
                {
                    this.noteEditorView.colorBnt.DropDownItems[i].ForeColor = Color.Black;    
                }
            }

           
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                this.noteEditorView.tipoLetraBtn.Items.Add(family.Name);
            }
        }

        private int ConvertToRGB(System.Drawing.Color c)
        {
            int r = c.R,
                g = c.G, 
                b = c.B; 
            int sum = 0;

         
            sum = r + g + b;
            return sum;
        }
    
        public void motrarHistorial(object sender, EventArgs e) {

            this.AccionesView = new Acciones();
            AccionesView.cargarTabla(historialUser);
            AccionesView.Show();
        
        }

        private void insertarImagen(object sender, EventArgs e)
        {
            if (this.noteEditorView.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(this.noteEditorView.openFileDialog1.FileName);
                    Clipboard.SetImage(img);
                    this.noteEditorView.cuadroTexto.Paste();
                    //hacer lo de oscar de acciones
                }
                catch
                {
                    MessageBox.Show("Formato incompatible, seleccione otra imagen.");
                }
            }

        }

        private void boldStripButton3_Click(object sender, EventArgs e)
        {

            if (this.noteEditorView.negritaBtn.Checked == false)
            {
                this.noteEditorView.negritaBtn.Checked = true; 
            }
            else if (this.noteEditorView.negritaBtn.Checked == true)
            {
                this.noteEditorView.negritaBtn.Checked = false;   
            }

            if (this.noteEditorView.cuadroTexto.SelectionFont == null)
            {
                return;
            }

          
            FontStyle style = this.noteEditorView.cuadroTexto.SelectionFont.Style;

           
            if (this.noteEditorView.cuadroTexto.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
            }
            else
            {
                style |= FontStyle.Bold;

            }
            this.noteEditorView.cuadroTexto.SelectionFont = new Font(this.noteEditorView.cuadroTexto.SelectionFont, style);     // sets the font style
        }

        private void underlineStripButton_Click(object sender, EventArgs e)
        {
            if (this.noteEditorView.subrayadoBtn.Checked == false)
            {
                this.noteEditorView.subrayadoBtn.Checked = true;    
            }
            else if (this.noteEditorView.subrayadoBtn.Checked == true)
            {
                this.noteEditorView.subrayadoBtn.Checked = false;   
            }
            if (this.noteEditorView.cuadroTexto.SelectionFont == null)
            {
                return;
            }

            
            FontStyle style = this.noteEditorView.cuadroTexto.SelectionFont.Style;

           
            if (this.noteEditorView.cuadroTexto.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            this.noteEditorView.cuadroTexto.SelectionFont = new Font(this.noteEditorView.cuadroTexto.SelectionFont, style);    // sets the font style
        }

        private void autoGuardado(object sender, EventArgs e)
        {

            this.noteEditorView.cuadroTexto.SaveFile(direccionAutoSave, RichTextBoxStreamType.RichText);

        }

        private void cambiarTamanioTexto(object sender, EventArgs e)
        {
            if (this.noteEditorView.cuadroTexto.SelectionFont == null)
            {
                return;
            }
            
            this.noteEditorView.cuadroTexto.SelectionFont = new Font(this.noteEditorView.cuadroTexto.SelectionFont.FontFamily, Convert.ToInt32(this.noteEditorView.tamanioLetraSlc.Text), this.noteEditorView.cuadroTexto.SelectionFont.Style);
        }

        private void cambiarTipoLetra(object sender, EventArgs e)
        {
            if (this.noteEditorView.cuadroTexto.SelectionFont == null)
            {
              
                this.noteEditorView.cuadroTexto.SelectionFont = new Font(this.noteEditorView.tipoLetraBtn.Text, this.noteEditorView.cuadroTexto.Font.Size);
            }
           
            this.noteEditorView.cuadroTexto.SelectionFont = new Font(this.noteEditorView.tipoLetraBtn.Text, this.noteEditorView.cuadroTexto.SelectionFont.Size);
        }

        private void guardar(object sender, EventArgs e)
        {
            try
            {
              
                string file;
                if (this.noteEditorView.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = this.noteEditorView.saveFileDialog1.FileName;
                    direccionAutoSave = filename;
                   
                    this.noteEditorView.cuadroTexto.SaveFile(filename, RichTextBoxStreamType.RichText);
                    file = Path.GetFileName(filename);   


                   
                    this.noteEditorView.timer1.Start();


                    MessageBox.Show("Documento " + file + " guardado!", "GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //guardar la var
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void abrirArchivo(object sender, EventArgs e)
        {
            this.noteEditorView.timer1.Stop();
     
            if (this.noteEditorView.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filenamee = this.noteEditorView.openFileDialog1.FileName;
             
                this.noteEditorView.cuadroTexto.LoadFile(filenamee, RichTextBoxStreamType.RichText);   
             
            }
        }

        private void colorTexto(object sender, ToolStripItemClickedEventArgs e)
        {
           
            KnownColor selectedColor;
            selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), e.ClickedItem.Text);  
            this.noteEditorView.cuadroTexto.SelectionColor = Color.FromKnownColor(selectedColor);    
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            
            if (this.noteEditorView.cuadroTexto.SelectionFont != null)
            {
                this.noteEditorView.negritaBtn.Checked = this.noteEditorView.cuadroTexto.SelectionFont.Bold;
                this.noteEditorView.italicabtn.Checked = this.noteEditorView.cuadroTexto.SelectionFont.Italic;
                this.noteEditorView.subrayadoBtn.Checked = this.noteEditorView.cuadroTexto.SelectionFont.Underline;
            }
        }

        private void alinearTextoIzquierda(object sender, EventArgs e)
        {
            
            this.noteEditorView.centrarTextoBtn.Checked = false;
            this.noteEditorView.alinearDerechaBtn.Checked = false;
            if (this.noteEditorView.alinearIzquierdaBtn.Checked == false)
            {
                this.noteEditorView.alinearIzquierdaBtn.Checked = true;   
            }
            else if (this.noteEditorView.alinearIzquierdaBtn.Checked == true)
            {
                this.noteEditorView.alinearIzquierdaBtn.Checked = false;   
            }
            this.noteEditorView.cuadroTexto.SelectionAlignment = HorizontalAlignment.Left;   
        }

        private void centrarTexto(object sender, EventArgs e)
        {
           
            this.noteEditorView.alinearIzquierdaBtn.Checked = false;
            this.noteEditorView.alinearDerechaBtn.Checked = false;
            if (this.noteEditorView.centrarTextoBtn.Checked == false)
            {
                this.noteEditorView.centrarTextoBtn.Checked = true;   
            }
            else if (this.noteEditorView.centrarTextoBtn.Checked == true)
            {
                this.noteEditorView.centrarTextoBtn.Checked = false;    
            }
            this.noteEditorView.cuadroTexto.SelectionAlignment = HorizontalAlignment.Center;     
        }

        private void alinearTextoDerecha(object sender, EventArgs e)
        {
           
            this.noteEditorView.alinearIzquierdaBtn.Checked = false;
            this.noteEditorView.centrarTextoBtn.Checked = false;

            if (this.noteEditorView.alinearDerechaBtn.Checked == false)
            {
                this.noteEditorView.alinearDerechaBtn.Checked = true;  
            }
            else if (this.noteEditorView.alinearDerechaBtn.Checked == true)
            {
                this.noteEditorView.alinearDerechaBtn.Checked = false;    
            }
            this.noteEditorView.cuadroTexto.SelectionAlignment = HorizontalAlignment.Right;    
        }

        private void enlistarTexto(object sender, EventArgs e)
        {
            if (this.noteEditorView.EnlistarBtn.Checked == false)
            {
                this.noteEditorView.EnlistarBtn.Checked = true;
                this.noteEditorView.cuadroTexto.SelectionBullet = true;    
            }
            else if (this.noteEditorView.EnlistarBtn.Checked == true)
            {
                this.noteEditorView.EnlistarBtn.Checked = false;
                this.noteEditorView.cuadroTexto.SelectionBullet = false;   
            }
        }

    

        private void richTextBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;    // copies data to the RTB
            else
                e.Effect = DragDropEffects.None;    // doesn't accept data into RTB
        }
     
        private void richTextBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // variables
            int i;
            String s;

           
            i = this.noteEditorView.cuadroTexto.SelectionStart;
            s = this.noteEditorView.cuadroTexto.Text.Substring(i);
            this.noteEditorView.cuadroTexto.Text = this.noteEditorView.cuadroTexto.Text.Substring(0, i);

           
            this.noteEditorView.cuadroTexto.Text += e.Data.GetData(DataFormats.Text).ToString();
            this.noteEditorView.cuadroTexto.Text += s;
        }

        private void anterior(object sender, EventArgs e)
        {
            if (contador == limite)
            {
                MessageBox.Show("No puede devolverse más ha superado el límite de devoluviones");
            }
            else
            {
                this.noteEditorView.cuadroTexto.Undo();
                contador++;
                limiteAcciones();
                mostrarContador();
                accionUsuario = new Accion(generadorCodigosHex(), Accion4);
                this.historialUser.Add(accionUsuario);
            }
        }

        private void siguiente(object sender, EventArgs e)
        {
            this.noteEditorView.cuadroTexto.Redo();
            if (0 < contador)
            {
                contador--;
            }
            mostrarContador();
            accionUsuario = new Accion(generadorCodigosHex(), Accion5);
            this.historialUser.Add(accionUsuario);

        }

    
      
        private void textoMayuscula(object sender, EventArgs e)
        {
            this.noteEditorView.cuadroTexto.SelectedText = this.noteEditorView.cuadroTexto.SelectedText.ToUpper();    // text to CAPS
        }

        private void textoMinuscula(object sender, EventArgs e)
        {
            this.noteEditorView.cuadroTexto.SelectedText = this.noteEditorView.cuadroTexto.SelectedText.ToLower();    // text to lowercase
        }

  

        private void printStripButton_Click(object sender, EventArgs e)
        {
           
            this.noteEditorView.printDialog.Document = this.noteEditorView.printDocument;
            if (this.noteEditorView.printDialog.ShowDialog() == DialogResult.OK)
            {
                this.noteEditorView.printDocument.Print();
            }
        }

        private void vistaPrevia(object sender, EventArgs e)
        {
            this.noteEditorView.printPreviewDialog.Document = this.noteEditorView.printDocument;
           
            this.noteEditorView.printPreviewDialog.ShowDialog();
        }

    
        void disparadorAcciones(object sender, KeyEventArgs e)
        {
           // limiteAcciones();

            if (e.KeyCode == Keys.Z && (e.Control))
            {
                if (contador == limite)
                {
                    MessageBox.Show("No puede devolverse más ha superado el límite de devoluviones");
                }
                else
                {
                    this.noteEditorView.cuadroTexto.Undo();
                    contador++;
                    accionUsuario = new Accion(generadorCodigosHex(), Accion4);
                    this.historialUser.Add(accionUsuario);
                    limiteAcciones();
                    mostrarContador();
                }
            }
            else if (e.KeyCode == Keys.Y && (e.Control))
            {

                this.noteEditorView.cuadroTexto.Redo();
                if (0 < contador)
                {
                    contador--;
                }
                accionUsuario = new Accion(generadorCodigosHex(), Accion5);
                this.historialUser.Add(accionUsuario);
                mostrarContador();

            }
            else if (e.KeyCode == Keys.X && (e.Control))
            {
                this.noteEditorView.cuadroTexto.Cut();
                contador++;
                accionUsuario = new Accion(generadorCodigosHex(), Accion1);
                this.historialUser.Add(accionUsuario);

                mostrarContador();

            }
            else if (e.KeyCode == Keys.C && (e.Control))
            {
                this.noteEditorView.cuadroTexto.Copy();
                contador++;
                accionUsuario = new Accion(generadorCodigosHex(), Accion6);
                this.historialUser.Add(accionUsuario);

                mostrarContador();

            }
            else if (e.KeyCode == Keys.V && (e.Control))
            {
                this.noteEditorView.cuadroTexto.Paste();
                contador++;
                accionUsuario = new Accion(generadorCodigosHex(), Accion2);
                this.historialUser.Add(accionUsuario);

                mostrarContador();
            }
            


        }
        void limiteAcciones()
        {
            if (contador >= limite)
            {
                MessageBox.Show("Ah llegado al límite de acciones que puede devolver");
                contador = limite;

            }
        }
        void mostrarContador() {
            //limiteAcciones();
            this.noteEditorView.lbContador.Text = contador.ToString();

        }
        private static string generadorCodigosHex()
        {
            Random rdm = new Random();
            string hexValue = string.Empty;
            int num;
            num = rdm.Next(0, int.MaxValue);
            hexValue += num.ToString("X8");
            return hexValue;
        }

    }
}
