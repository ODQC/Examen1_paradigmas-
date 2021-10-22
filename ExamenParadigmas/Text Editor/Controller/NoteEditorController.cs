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
        int pos, line, column;    

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
            this.noteEditorView.richTextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDown);
            this.noteEditorView.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            this.noteEditorView.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            this.noteEditorView.verHistorialMenuItem.Click += new System.EventHandler(this.motrarHistorial);
            this.noteEditorView.tipoLetraBtn.SelectedIndexChanged += new System.EventHandler(this.fontStripComboBox_SelectedIndexChanged);
            this.noteEditorView.tamanioLetraSlc.Click += new System.EventHandler(this.fontSizeComboBox_SelectedIndexChanged);
            this.noteEditorView.tamanioLetraSlc.SelectedIndexChanged += new System.EventHandler(this.fontSizeComboBox_SelectedIndexChanged);
            this.noteEditorView.colorBnt.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.colorStripDropDownButton_DropDownItemClicked);
            this.noteEditorView.lowercaseToolStripMenuItem.Click += new System.EventHandler(this.lowercaseToolStripMenuItem_Click);
            this.noteEditorView.uppercaseToolStripMenuItem.Click += new System.EventHandler(this.uppercaseToolStripMenuItem_Click);
            this.noteEditorView.zoomDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.zoomDropDownButton_DropDownItemClicked);
            
            this.noteEditorView.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            this.noteEditorView.fontDialog1.HelpRequest += new System.EventHandler(this.fontDialog1_HelpRequest);
            this.noteEditorView.colorDialog1.HelpRequest += new System.EventHandler(this.colorDialog1_HelpRequest);
            this.noteEditorView.richTextBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.richTextBox1_DragDrop);
            this.noteEditorView.richTextBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.richTextBox1_DragEnter);
            this.noteEditorView.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.noteEditorView.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
            this.noteEditorView.deleteStripMenuItem.Click += new System.EventHandler(this.deleteStripMenuItem_Click);
            this.noteEditorView.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            this.noteEditorView.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            this.noteEditorView.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            this.noteEditorView.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            this.noteEditorView.Load += new EventHandler(this.frmEditor_Load);

            this.noteEditorView.richTextBox1.KeyUp += new KeyEventHandler(disparadorAcciones);
            this.noteEditorView.cutToolStripMenuItem.Click += new EventHandler(cutToolStripMenuItem_Click);
            this.noteEditorView.copyToolStripMenuItem.Click += new EventHandler(copyToolStripMenuItem_Click);
            this.noteEditorView.pasteToolStripMenuItem.Click += new EventHandler(pasteToolStripMenuItem_Click);
            this.noteEditorView.clearToolStripMenuItem.Click += new EventHandler(clearToolStripMenuItem_Click);
            this.noteEditorView.selectAllToolStripMenuItem.Click += new EventHandler(selectAllToolStripMenuItem_Click);
            this.noteEditorView.vistaPreviaBtn.Click += new EventHandler(printPreviewStripButton_Click);
            this.noteEditorView.guardarBtn.Click += new EventHandler(saveStripButton_Click);
            this.noteEditorView.abrirBtn.Click += new EventHandler(openFileStripButton_Click);
            this.noteEditorView.tipoLetraBtn.Click += new EventHandler(fontStripComboBox_SelectedIndexChanged);
            this.noteEditorView.tamanioLetraSlc.Click += new EventHandler(fontSizeComboBox_SelectedIndexChanged);

            this.noteEditorView.alinearIzquierdaBtn.Click += new EventHandler(leftAlignStripButton_Click);
            this.noteEditorView.centrarTextoBtn.Click += new EventHandler(centerAlignStripButton_Click);
            this.noteEditorView.alinearDerechaBtn.Click += new EventHandler(rightAlignStripButton_Click);
            this.noteEditorView.EnlistarBtn.Click += new EventHandler(bulletListStripButton_Click);
            this.noteEditorView.atrasBtn.Click += new EventHandler(undoStripButton_Click);
            this.noteEditorView.siguienteBtn.Click += new EventHandler(redoStripButton_Click);
        }
        private void frmEditor_Load(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.AllowDrop = true;     // to allow drag and drop to the RichTextBox
            this.noteEditorView.richTextBox1.AcceptsTab = true;    // allow tab
            this.noteEditorView.richTextBox1.WordWrap = false;    // disable word wrap on start
            this.noteEditorView.richTextBox1.ShortcutsEnabled = false;    // allow shortcuts
            this.noteEditorView.richTextBox1.DetectUrls = true;    // allow detect url
            this.noteEditorView.fontDialog1.ShowColor = true;
            this.noteEditorView.fontDialog1.ShowApply = true;
            this.noteEditorView.fontDialog1.ShowHelp = true;
            this.noteEditorView.colorDialog1.AllowFullOpen = true;
            this.noteEditorView.colorDialog1.AnyColor = true;
            this.noteEditorView.colorDialog1.SolidColorOnly = false;
            this.noteEditorView.colorDialog1.ShowHelp = true;
            this.noteEditorView.colorDialog1.AnyColor = true;
            this.noteEditorView.alinearIzquierdaBtn.Checked = true;
            this.noteEditorView.centrarTextoBtn.Checked = false;
            this.noteEditorView.alinearDerechaBtn.Checked = false;
            this.noteEditorView.negritaBtn.Checked = false;
            this.noteEditorView.italicabtn.Checked = false;
            this.noteEditorView.alinearDerechaBtn.Checked = false;
            this.noteEditorView.EnlistarBtn.Checked = false;
            this.noteEditorView.wordWrapToolStripMenuItem.Image = null;
            this.noteEditorView.MinimizeBox = false;
            this.noteEditorView.MaximizeBox = false;
            this.noteEditorView.FormBorderStyle = FormBorderStyle.FixedSingle;

            // fill zoomDropDownButton item list
            this.noteEditorView.zoomDropDownButton.DropDown.Items.Add("20%");
            this.noteEditorView.zoomDropDownButton.DropDown.Items.Add("50%");
            this.noteEditorView.zoomDropDownButton.DropDown.Items.Add("70%");
            this.noteEditorView.zoomDropDownButton.DropDown.Items.Add("100%");
            this.noteEditorView.zoomDropDownButton.DropDown.Items.Add("150%");
            this.noteEditorView.zoomDropDownButton.DropDown.Items.Add("200%");
            this.noteEditorView.zoomDropDownButton.DropDown.Items.Add("300%");
            this.noteEditorView.zoomDropDownButton.DropDown.Items.Add("400%");
            this.noteEditorView.zoomDropDownButton.DropDown.Items.Add("500%");

            // fill font sizes in combo box
            for (int i = 8; i < 80; i += 2)
            {
                this.noteEditorView.tamanioLetraSlc.Items.Add(i);
            }

            // fill colors in color drop down list
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                {
                    colorList.Add(prop.Name);
                }
            }

            // fill the drop down items list
            foreach (string color in colorList)
            {
                this.noteEditorView.colorBnt.DropDownItems.Add(color);
            }

            // fill BackColor for each color in the DropDownItems list
            for (int i = 0; i < this.noteEditorView.colorBnt.DropDownItems.Count; i++)
            {
                // Create KnownColor object
                KnownColor selectedColor;
                selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), colorList[i]);    // parse to a KnownColor
                this.noteEditorView.colorBnt.DropDownItems[i].BackColor = Color.FromKnownColor(selectedColor);    // set the BackColor to its appropriate list item

                // Set the text color depending on if the barkground is darker or lighter
                // create Color object
                Color col = Color.FromName(colorList[i]);

                // 255,255,255 = White and 0,0,0 = Black
                // Max sum of RGB values is 765 -> (255 + 255 + 255)
                // Middle sum of RGB values is 382 -> (765/2)
                // Color is considered darker if its <= 382
                // Color is considered lighter if its > 382
                sumRGB = ConvertToRGB(col);    // get the color objects sum of the RGB value
                if (sumRGB <= MIDDLE)    // Darker Background
                {
                    this.noteEditorView.colorBnt.DropDownItems[i].ForeColor = Color.White;    // set to White text
                }
                else if (sumRGB > MIDDLE)    // Lighter Background
                {
                    this.noteEditorView.colorBnt.DropDownItems[i].ForeColor = Color.Black;    // set to Black text
                }
            }

            // fill fonts in font combo box
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                this.noteEditorView.tipoLetraBtn.Items.Add(family.Name);
            }

            // determines the line and column numbers of mouse position on the richTextBox
            int pos = this.noteEditorView.richTextBox1.SelectionStart;
            int line = this.noteEditorView.richTextBox1.GetLineFromCharIndex(pos);
            int column = this.noteEditorView.richTextBox1.SelectionStart - this.noteEditorView.richTextBox1.GetFirstCharIndexFromLine(line);
            this.noteEditorView.lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.SelectAll();     // select all text
        }
        private int ConvertToRGB(System.Drawing.Color c)
        {
            int r = c.R, // RED component value
                g = c.G, // GREEN component value
                b = c.B; // BLUE component value
            int sum = 0;

            // calculate sum of RGB
            sum = r + g + b;

            return sum;
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear
            this.noteEditorView.richTextBox1.Clear();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.Paste();     // paste text
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.Copy();      // copy text
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.Cut();     // cut text
        }
        public void motrarHistorial(object sender, EventArgs e) {

            this.AccionesView = new Acciones();
            AccionesView.cargarTabla(historialUser);
            AccionesView.Show();
        
        }
        private void boldStripButton3_Click(object sender, EventArgs e)
        {

            if (this.noteEditorView.negritaBtn.Checked == false)
            {
                this.noteEditorView.negritaBtn.Checked = true; // BOLD is true
            }
            else if (this.noteEditorView.negritaBtn.Checked == true)
            {
                this.noteEditorView.negritaBtn.Checked = false;    // BOLD is false
            }

            if (this.noteEditorView.richTextBox1.SelectionFont == null)
            {
                return;
            }

            // create fontStyle object
            FontStyle style = this.noteEditorView.richTextBox1.SelectionFont.Style;

            // determines the font style
            if (this.noteEditorView.richTextBox1.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
            }
            else
            {
                style |= FontStyle.Bold;

            }
            this.noteEditorView.richTextBox1.SelectionFont = new Font(this.noteEditorView.richTextBox1.SelectionFont, style);     // sets the font style
        }

        private void underlineStripButton_Click(object sender, EventArgs e)
        {
            if (this.noteEditorView.subrayadoBtn.Checked == false)
            {
                this.noteEditorView.subrayadoBtn.Checked = true;     // UNDERLINE is active
            }
            else if (this.noteEditorView.subrayadoBtn.Checked == true)
            {
                this.noteEditorView.subrayadoBtn.Checked = false;    // UNDERLINE is not active
            }

            if (this.noteEditorView.richTextBox1.SelectionFont == null)
            {
                return;
            }

            // create fontStyle object
            FontStyle style = this.noteEditorView.richTextBox1.SelectionFont.Style;

            // determines the font style
            if (this.noteEditorView.richTextBox1.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            this.noteEditorView.richTextBox1.SelectionFont = new Font(this.noteEditorView.richTextBox1.SelectionFont, style);    // sets the font style
        }

       

        private void fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.noteEditorView.richTextBox1.SelectionFont == null)
            {
                return;
            }
            // sets the font size when changed
            this.noteEditorView.richTextBox1.SelectionFont = new Font(this.noteEditorView.richTextBox1.SelectionFont.FontFamily, Convert.ToInt32(this.noteEditorView.tamanioLetraSlc.Text), this.noteEditorView.richTextBox1.SelectionFont.Style);
        }

        private void fontStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.noteEditorView.richTextBox1.SelectionFont == null)
            {
                // sets the Font Family style
                this.noteEditorView.richTextBox1.SelectionFont = new Font(this.noteEditorView.tipoLetraBtn.Text, this.noteEditorView.richTextBox1.Font.Size);
            }
            // sets the selected font famly style
            this.noteEditorView.richTextBox1.SelectionFont = new Font(this.noteEditorView.tipoLetraBtn.Text, this.noteEditorView.richTextBox1.SelectionFont.Size);
        }

        private void saveStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.noteEditorView.saveFileDialog1.ShowDialog();    // show the dialog
                string file;
                if (this.noteEditorView.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = this.noteEditorView.saveFileDialog1.FileName;
                    // save the contents of the rich text box
                    this.noteEditorView.richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                    file = Path.GetFileName(filename);    // get name of file
                    MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openFileStripButton_Click(object sender, EventArgs e)
        {
            this.noteEditorView.openFileDialog1.ShowDialog();     // show the dialog
            if (this.noteEditorView.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filenamee = this.noteEditorView.openFileDialog1.FileName;
                // load the file into the richTextBox
                this.noteEditorView.richTextBox1.LoadFile(filenamee, RichTextBoxStreamType.PlainText);    // loads it in regular text format
                // richTextBox1.LoadFile(filename, RichTextBoxStreamType.RichText);    // loads it in RTB format
            }
        }

        private void colorStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // creates a KnownColor object
            KnownColor selectedColor;
            selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), e.ClickedItem.Text);    // converts it to a Color Structure
            this.noteEditorView.richTextBox1.SelectionColor = Color.FromKnownColor(selectedColor);    // sets the selected color
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            // highlight button border when buttons are true
            if (this.noteEditorView.richTextBox1.SelectionFont != null)
            {
                this.noteEditorView.negritaBtn.Checked = this.noteEditorView.richTextBox1.SelectionFont.Bold;
                this.noteEditorView.italicabtn.Checked = this.noteEditorView.richTextBox1.SelectionFont.Italic;
                this.noteEditorView.subrayadoBtn.Checked = this.noteEditorView.richTextBox1.SelectionFont.Underline;
            }
        }

        private void leftAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            this.noteEditorView.centrarTextoBtn.Checked = false;
            this.noteEditorView.alinearDerechaBtn.Checked = false;
            if (this.noteEditorView.alinearIzquierdaBtn.Checked == false)
            {
                this.noteEditorView.alinearIzquierdaBtn.Checked = true;    // LEFT ALIGN is active
            }
            else if (this.noteEditorView.alinearIzquierdaBtn.Checked == true)
            {
                this.noteEditorView.alinearIzquierdaBtn.Checked = false;    // LEFT ALIGN is not active
            }
            this.noteEditorView.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;    // selects left alignment
        }

        private void centerAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            this.noteEditorView.alinearIzquierdaBtn.Checked = false;
            this.noteEditorView.alinearDerechaBtn.Checked = false;
            if (this.noteEditorView.centrarTextoBtn.Checked == false)
            {
                this.noteEditorView.centrarTextoBtn.Checked = true;    // CENTER ALIGN is active
            }
            else if (this.noteEditorView.centrarTextoBtn.Checked == true)
            {
                this.noteEditorView.centrarTextoBtn.Checked = false;    // CENTER ALIGN is not active
            }
            this.noteEditorView.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;     // selects center alignment
        }

        private void rightAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            this.noteEditorView.alinearIzquierdaBtn.Checked = false;
            this.noteEditorView.centrarTextoBtn.Checked = false;

            if (this.noteEditorView.alinearDerechaBtn.Checked == false)
            {
                this.noteEditorView.alinearDerechaBtn.Checked = true;    // RIGHT ALIGN is active
            }
            else if (this.noteEditorView.alinearDerechaBtn.Checked == true)
            {
                this.noteEditorView.alinearDerechaBtn.Checked = false;    // RIGHT ALIGN is not active
            }
            this.noteEditorView.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;    // selects right alignment
        }

        private void bulletListStripButton_Click(object sender, EventArgs e)
        {
            if (this.noteEditorView.EnlistarBtn.Checked == false)
            {
                this.noteEditorView.EnlistarBtn.Checked = true;
                this.noteEditorView.richTextBox1.SelectionBullet = true;    // BULLET LIST is active
            }
            else if (this.noteEditorView.EnlistarBtn.Checked == true)
            {
                this.noteEditorView.EnlistarBtn.Checked = false;
                this.noteEditorView.richTextBox1.SelectionBullet = false;    // BULLET LIST is not active
            }
        }

        private void increaseStripButton_Click(object sender, EventArgs e)
        {
            string fontSizeNum = this.noteEditorView.tamanioLetraSlc.Text;    // variable to hold selected size         
            try
            {
                int size = Convert.ToInt32(fontSizeNum) + 1;    // convert (fontSizeNum + 1)
                if (this.noteEditorView.richTextBox1.SelectionFont == null)
                {
                    return;
                }
                // sets the updated font size
                this.noteEditorView.richTextBox1.SelectionFont = new Font(this.noteEditorView.richTextBox1.SelectionFont.FontFamily, size, this.noteEditorView.richTextBox1.SelectionFont.Style);
                this.noteEditorView.tamanioLetraSlc.Text = size.ToString();    // update font size
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
            }
        }

        private void decreaseStripButton_Click(object sender, EventArgs e)
        {
            string fontSizeNum = this.noteEditorView.tamanioLetraSlc.Text;    // variable to hold selected size            
            try
            {
                int size = Convert.ToInt32(fontSizeNum) - 1;    // convert (fontSizeNum - 1)
                if (this.noteEditorView.richTextBox1.SelectionFont == null)
                {
                    return;
                }
                // sets the updated font size
                this.noteEditorView.richTextBox1.SelectionFont = new Font(this.noteEditorView.richTextBox1.SelectionFont.FontFamily, size, this.noteEditorView.richTextBox1.SelectionFont.Style);
                this.noteEditorView.tamanioLetraSlc.Text = size.ToString();    // update font size
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
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

            // Get start position to drop the text.
            i = this.noteEditorView.richTextBox1.SelectionStart;
            s = this.noteEditorView.richTextBox1.Text.Substring(i);
            this.noteEditorView.richTextBox1.Text = this.noteEditorView.richTextBox1.Text.Substring(0, i);

            // Drop the text on to the RichTextBox.
            this.noteEditorView.richTextBox1.Text += e.Data.GetData(DataFormats.Text).ToString();
            this.noteEditorView.richTextBox1.Text += s;
        }

        private void undoStripButton_Click(object sender, EventArgs e)
        {
            if (contador == limite)
            {
                MessageBox.Show("No puede devolverse más ha superado el límite de devoluviones");
            }
            else
            {
                this.noteEditorView.richTextBox1.Undo();
                contador++;
                mostrarContador();
                accionUsuario = new Accion(generadorCodigosHex(), Accion4);
                this.historialUser.Add(accionUsuario);
            }
        }

        private void redoStripButton_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.Redo();
            contador--;
            mostrarContador();
            accionUsuario = new Accion(generadorCodigosHex(), Accion5);
            this.historialUser.Add(accionUsuario);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.Close();     // close the form
        }

       

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.Cut();     // cut text
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            this.noteEditorView.richTextBox1.Copy();     // copy text
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.Paste();    // paste text
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.SelectAll();    // select all text
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear the rich text box
            this.noteEditorView.richTextBox1.Clear();
            this.noteEditorView.richTextBox1.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // delete selected text
            this.noteEditorView.richTextBox1.SelectedText = "";
            this.noteEditorView.richTextBox1.Focus();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.openFileDialog1.ShowDialog();
            if (this.noteEditorView.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.noteEditorView.richTextBox1.LoadFile(this.noteEditorView.openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                // richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);  // loads the file in RTB format
            }
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {

            if (this.noteEditorView.richTextBox1.Text != string.Empty)    // RTB has contents - prompt user to save changes
            {
                // save changes message
                DialogResult result = MessageBox.Show("Would you like to save your changes? Editor is not empty.", "Save Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // save the RTB contents if user selected yes
                    this.noteEditorView.saveFileDialog1.ShowDialog();    // show the dialog
                    string file;
                    if (this.noteEditorView.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string filename = this.noteEditorView.saveFileDialog1.FileName;
                        // save the contents of the rich text box
                        this.noteEditorView.richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                        file = Path.GetFileName(filename); // get name of file
                        MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // finally - clear the contents of the RTB 
                    this.noteEditorView.richTextBox1.ResetText();
                    this.noteEditorView.richTextBox1.Focus();
                }
                else if (result == DialogResult.No)
                {
                    // clear the contents of the RTB 
                    this.noteEditorView.richTextBox1.ResetText();
                    this.noteEditorView.richTextBox1.Focus();
                }
            }
            else // RTB has no contents
            {
                // clear the contents of the RTB 
                this.noteEditorView.richTextBox1.ResetText();
                this.noteEditorView.richTextBox1.Focus();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.saveFileDialog1.ShowDialog();    // show the dialog
            string file;

            if (this.noteEditorView.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = this.noteEditorView.saveFileDialog1.FileName;
                // save the contents of the rich text box
                this.noteEditorView.richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
            }
            file = Path.GetFileName(filenamee);    // get name of file
            MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void zoomDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            float zoomPercent = Convert.ToSingle(e.ClickedItem.Text.Trim('%')); // convert
            this.noteEditorView.richTextBox1.ZoomFactor = zoomPercent / 100;    // set zoom factor

            if (e.ClickedItem.Image == null)
            {
                // sets all the image properties to null - incase one is already selected beforehand
                for (int i = 0; i < this.noteEditorView.zoomDropDownButton.DropDownItems.Count; i++)
                {
                    this.noteEditorView.zoomDropDownButton.DropDownItems[i].Image = null;
                }

                // draw bmp in image property of selected item, while its active
                Bitmap bmp = new Bitmap(5, 5);
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    gfx.FillEllipse(Brushes.Black, 1, 1, 3, 3);
                }
                e.ClickedItem.Image = bmp;    // draw ellipse in image property
            }
            else
            {
                e.ClickedItem.Image = null;
                this.noteEditorView.richTextBox1.ZoomFactor = 1.0f;    // set back to NO ZOOM
            }
        }

        private void uppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.SelectedText = this.noteEditorView.richTextBox1.SelectedText.ToUpper();    // text to CAPS
        }

        private void lowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.SelectedText = this.noteEditorView.richTextBox1.SelectedText.ToLower();    // text to lowercase
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // draw bmp in image property of selected item, while its active
            Bitmap bmp = new Bitmap(5, 5);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.FillEllipse(Brushes.Black, 1, 1, 3, 3);
            }

            if (this.noteEditorView.richTextBox1.WordWrap == false)
            {
                this.noteEditorView.richTextBox1.WordWrap = true;    // WordWrap is active
                this.noteEditorView.wordWrapToolStripMenuItem.Image = bmp;    // draw ellipse in image property
            }
            else if (this.noteEditorView.richTextBox1.WordWrap == true)
            {
                this.noteEditorView.richTextBox1.WordWrap = false;    // WordWrap is not active
                this.noteEditorView.wordWrapToolStripMenuItem.Image = null;    // clear image property
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.noteEditorView.fontDialog1.ShowDialog();    // show the Font Dialog
                System.Drawing.Font oldFont = this.noteEditorView.Font;    // gets current font

                if (this.noteEditorView.fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    fontDialog1_Apply(this.noteEditorView.richTextBox1, new System.EventArgs());
                }
                // set back to the recent font
                else if (this.noteEditorView.fontDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    // set current font back to the old font
                    this.noteEditorView.Font = oldFont;

                    // sets the old font for the controls inside richTextBox1
                    foreach (Control containedControl in this.noteEditorView.richTextBox1.Controls)
                    {
                        containedControl.Font = oldFont;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // error
            }
        }

        private void fontDialog1_HelpRequest(object sender, EventArgs e)
        {
            // display HelpRequest message
            MessageBox.Show("Please choose a font and any other attributes; then hit Apply and OK.", "Font Dialog Help Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            this.noteEditorView.fontDialog1.FontMustExist = true;    // error if font doesn't exist

            this.noteEditorView.richTextBox1.Font = this.noteEditorView.fontDialog1.Font;    // set selected font (Includes: FontFamily, Size, and, Effect. No need to set them separately)
            this.noteEditorView.richTextBox1.ForeColor = this.noteEditorView.fontDialog1.Color;    // set selected font color

            // sets the font for the controls inside richTextBox1
            foreach (Control containedControl in this.noteEditorView.richTextBox1.Controls)
            {
                containedControl.Font = this.noteEditorView.fontDialog1.Font;
            }
        }

        private void deleteStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.richTextBox1.SelectedText = ""; // delete selected text
        }

        private void clearFormattingStripButton_Click(object sender, EventArgs e)
        {
            this.noteEditorView.tipoLetraBtn.Text = "Font Family";
            this.noteEditorView.tamanioLetraSlc.Text = "Font Size";
            string pureText = this.noteEditorView.richTextBox1.Text;    // get the current Plain Text     
            this.noteEditorView.richTextBox1.Clear();    // clear RTB
            this.noteEditorView.richTextBox1.ForeColor = Color.Black;    // ensure the text color is back to Black
            this.noteEditorView.richTextBox1.Font = default(Font);    // set default font
            this.noteEditorView.richTextBox1.Text = pureText;    // Set it back to its orginial text, added as plain text
            this.noteEditorView.alinearDerechaBtn.Checked = false;
            this.noteEditorView.centrarTextoBtn.Checked = false;
            this.noteEditorView.alinearIzquierdaBtn.Checked = true;
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // draws the string onto the print document
            e.Graphics.DrawString(this.noteEditorView.richTextBox1.Text, this.noteEditorView.richTextBox1.Font, Brushes.Black, 100, 20);
            e.Graphics.PageUnit = GraphicsUnit.Inch;
        }

        private void printStripButton_Click(object sender, EventArgs e)
        {
            // printDialog associates with PrintDocument
            this.noteEditorView.printDialog.Document = this.noteEditorView.printDocument;
            if (this.noteEditorView.printDialog.ShowDialog() == DialogResult.OK)
            {
                this.noteEditorView.printDocument.Print(); // Print the document
            }
        }

        private void printPreviewStripButton_Click(object sender, EventArgs e)
        {
            this.noteEditorView.printPreviewDialog.Document = this.noteEditorView.printDocument;
            // Show PrintPreview Dialog 
            this.noteEditorView.printPreviewDialog.ShowDialog();
        }

        private void printStripMenuItem_Click(object sender, EventArgs e)
        {
            // printDialog associates with PrintDocument
            this.noteEditorView.printDialog.Document = this.noteEditorView.printDocument;
            if (this.noteEditorView.printDialog.ShowDialog() == DialogResult.OK)
            {
                this.noteEditorView.printDocument.Print();
            }
        }

        private void printPreviewStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.printPreviewDialog.Document = this.noteEditorView.printDocument;
            // Show PrintPreview Dialog 
            this.noteEditorView.printPreviewDialog.ShowDialog();
        }

        private void colorDialog1_HelpRequest(object sender, EventArgs e)
        {
            // display HelpRequest message
            MessageBox.Show("Please select a color by clicking it. This will change the text color.", "Color Dialog Help Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void colorOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.noteEditorView.colorDialog1.ShowDialog();

            if (this.noteEditorView.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // set the selected color to the RTB's forecolor
                this.noteEditorView.richTextBox1.ForeColor = this.noteEditorView.colorDialog1.Color;
            }
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            // determine key released
            switch (e.KeyCode)
            {
                case Keys.Down:
                    pos = this.noteEditorView.richTextBox1.SelectionStart;    // get starting point
                    line = this.noteEditorView.richTextBox1.GetLineFromCharIndex(pos);    // get line number
                    column = this.noteEditorView.richTextBox1.SelectionStart - this.noteEditorView.richTextBox1.GetFirstCharIndexFromLine(line);    // get column number
                    this.noteEditorView.lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Right:
                    pos = this.noteEditorView.richTextBox1.SelectionStart; // get starting point
                    line = this.noteEditorView.richTextBox1.GetLineFromCharIndex(pos); // get line number
                    column = this.noteEditorView.richTextBox1.SelectionStart - this.noteEditorView.richTextBox1.GetFirstCharIndexFromLine(line);    // get column number
                    this.noteEditorView.lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Up:
                    pos = this.noteEditorView.richTextBox1.SelectionStart; // get starting point
                    line = this.noteEditorView.richTextBox1.GetLineFromCharIndex(pos); // get line number
                    column = this.noteEditorView.richTextBox1.SelectionStart - this.noteEditorView.richTextBox1.GetFirstCharIndexFromLine(line);    // get column number
                    this.noteEditorView.lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Left:
                    pos = this.noteEditorView.richTextBox1.SelectionStart; // get starting point
                    line = this.noteEditorView.richTextBox1.GetLineFromCharIndex(pos); // get line number
                    column = this.noteEditorView.richTextBox1.SelectionStart - this.noteEditorView.richTextBox1.GetFirstCharIndexFromLine(line);    // get column number
                    this.noteEditorView.lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
            }
        }

     
        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int pos = this.noteEditorView.richTextBox1.SelectionStart;    // get starting point
            int line = this.noteEditorView.richTextBox1.GetLineFromCharIndex(pos);    // get line number
            int column = this.noteEditorView.richTextBox1.SelectionStart - this.noteEditorView.richTextBox1.GetFirstCharIndexFromLine(line);    // get column number
            this.noteEditorView.lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
        }
        void disparadorAcciones(object sender, KeyEventArgs e)
        {
            limiteAcciones();

            if (e.KeyCode == Keys.Z && (e.Control))
            {
                if (contador == limite)
                {
                    MessageBox.Show("No puede devolverse más ha superado el límite de devoluviones");
                }
                else
                {
                    this.noteEditorView.richTextBox1.Undo();
                    contador++;
                    accionUsuario = new Accion(generadorCodigosHex(), Accion4);
                    this.historialUser.Add(accionUsuario);
                }
            }
            else if (e.KeyCode == Keys.Y && (e.Control))
            {
                this.noteEditorView.richTextBox1.Redo();
                contador--;
                accionUsuario = new Accion(generadorCodigosHex(), Accion5);
                this.historialUser.Add(accionUsuario);

            }
            else if (e.KeyCode == Keys.X && (e.Control))
            {
                this.noteEditorView.richTextBox1.Cut();
                contador++;
                accionUsuario = new Accion(generadorCodigosHex(), Accion1);
                this.historialUser.Add(accionUsuario);


            }
            else if (e.KeyCode == Keys.C && (e.Control))
            {
                this.noteEditorView.richTextBox1.Copy();
                contador++;
                accionUsuario = new Accion(generadorCodigosHex(), Accion6);
                this.historialUser.Add(accionUsuario);


            }
            else if (e.KeyCode == Keys.V && (e.Control))
            {
                this.noteEditorView.richTextBox1.Paste();
                contador++;
                accionUsuario = new Accion(generadorCodigosHex(), Accion2);
                this.historialUser.Add(accionUsuario);

            }
            

            mostrarContador();

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
            limiteAcciones();
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
