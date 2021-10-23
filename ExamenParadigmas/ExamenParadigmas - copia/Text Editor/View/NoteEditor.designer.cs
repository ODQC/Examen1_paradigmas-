namespace NoteEditor
{
    partial class TextEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditor));
            this.cuadroTexto = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.guardarBtn = new System.Windows.Forms.ToolStripButton();
            this.abrirBtn = new System.Windows.Forms.ToolStripButton();
            this.imprimirBtn = new System.Windows.Forms.ToolStripButton();
            this.vistaPreviaBtn = new System.Windows.Forms.ToolStripButton();
            this.atrasBtn = new System.Windows.Forms.ToolStripButton();
            this.siguienteBtn = new System.Windows.Forms.ToolStripButton();
            this.tipoLetraBtn = new System.Windows.Forms.ToolStripComboBox();
            this.tamanioLetraSlc = new System.Windows.Forms.ToolStripComboBox();
            this.colorBnt = new System.Windows.Forms.ToolStripDropDownButton();
            this.mayusculasBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.lowercaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uppercaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarBtn = new System.Windows.Forms.ToolStripButton();
            this.negritaBtn = new System.Windows.Forms.ToolStripButton();
            this.italicabtn = new System.Windows.Forms.ToolStripButton();
            this.subrayadoBtn = new System.Windows.Forms.ToolStripButton();
            this.alinearIzquierdaBtn = new System.Windows.Forms.ToolStripButton();
            this.centrarTextoBtn = new System.Windows.Forms.ToolStripButton();
            this.alinearDerechaBtn = new System.Windows.Forms.ToolStripButton();
            this.EnlistarBtn = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.historialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verHistorialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbLimite = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbContador = new System.Windows.Forms.Label();
            this.imagenA = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.cuadroTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuadroTexto.Location = new System.Drawing.Point(166, 94);
            this.cuadroTexto.Name = "richTextBox1";
            this.cuadroTexto.Size = new System.Drawing.Size(624, 656);
            this.cuadroTexto.TabIndex = 0;
            this.cuadroTexto.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 773);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 5);
            this.panel2.TabIndex = 15;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarBtn,
            this.abrirBtn,
            this.imprimirBtn,
            this.vistaPreviaBtn,
            this.atrasBtn,
            this.siguienteBtn,
            this.tipoLetraBtn,
            this.tamanioLetraSlc,
            this.colorBnt,
            this.mayusculasBtn,
            this.borrarBtn,
            this.negritaBtn,
            this.italicabtn,
            this.subrayadoBtn,
            this.alinearIzquierdaBtn,
            this.centrarTextoBtn,
            this.alinearDerechaBtn,
            this.EnlistarBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 50);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(955, 31);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // guardarBtn
            // 
            this.guardarBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.guardarBtn.Image = ((System.Drawing.Image)(resources.GetObject("guardarBtn.Image")));
            this.guardarBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarBtn.Name = "guardarBtn";
            this.guardarBtn.Size = new System.Drawing.Size(28, 28);
            this.guardarBtn.Text = "Save File";
            // 
            // abrirBtn
            // 
            this.abrirBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrirBtn.Image = ((System.Drawing.Image)(resources.GetObject("abrirBtn.Image")));
            this.abrirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirBtn.Name = "abrirBtn";
            this.abrirBtn.Size = new System.Drawing.Size(28, 28);
            this.abrirBtn.Text = "Open File";
            // 
            // imprimirBtn
            // 
            this.imprimirBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimirBtn.Image = ((System.Drawing.Image)(resources.GetObject("imprimirBtn.Image")));
            this.imprimirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimirBtn.Name = "imprimirBtn";
            this.imprimirBtn.Size = new System.Drawing.Size(28, 28);
            this.imprimirBtn.Text = "Print Page";
            // 
            // vistaPreviaBtn
            // 
            this.vistaPreviaBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.vistaPreviaBtn.Image = ((System.Drawing.Image)(resources.GetObject("vistaPreviaBtn.Image")));
            this.vistaPreviaBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.vistaPreviaBtn.Name = "vistaPreviaBtn";
            this.vistaPreviaBtn.Size = new System.Drawing.Size(28, 28);
            this.vistaPreviaBtn.Text = "Print Preview";
            // 
            // atrasBtn
            // 
            this.atrasBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.atrasBtn.Image = ((System.Drawing.Image)(resources.GetObject("atrasBtn.Image")));
            this.atrasBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.atrasBtn.Name = "atrasBtn";
            this.atrasBtn.Size = new System.Drawing.Size(28, 28);
            this.atrasBtn.Text = "Undo Move";
            // 
            // siguienteBtn
            // 
            this.siguienteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.siguienteBtn.Image = ((System.Drawing.Image)(resources.GetObject("siguienteBtn.Image")));
            this.siguienteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.siguienteBtn.Name = "siguienteBtn";
            this.siguienteBtn.Size = new System.Drawing.Size(28, 28);
            this.siguienteBtn.Text = "Redo Move";
            // 
            // tipoLetraBtn
            // 
            this.tipoLetraBtn.Name = "tipoLetraBtn";
            this.tipoLetraBtn.Size = new System.Drawing.Size(155, 31);
            this.tipoLetraBtn.Sorted = true;
            this.tipoLetraBtn.Text = "Tipo de letra";
            this.tipoLetraBtn.ToolTipText = "Font Family";
            // 
            // tamanioLetraSlc
            // 
            this.tamanioLetraSlc.AutoSize = false;
            this.tamanioLetraSlc.Name = "tamanioLetraSlc";
            this.tamanioLetraSlc.Size = new System.Drawing.Size(73, 23);
            this.tamanioLetraSlc.Text = "8";
            this.tamanioLetraSlc.ToolTipText = "Font Size";
            // 
            // colorBnt
            // 
            this.colorBnt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorBnt.Image = ((System.Drawing.Image)(resources.GetObject("colorBnt.Image")));
            this.colorBnt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorBnt.Name = "colorBnt";
            this.colorBnt.Size = new System.Drawing.Size(37, 28);
            this.colorBnt.Text = "Font Color";
            // 
            // mayusculasBtn
            // 
            this.mayusculasBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mayusculasBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowercaseToolStripMenuItem,
            this.uppercaseToolStripMenuItem});
            this.mayusculasBtn.Image = ((System.Drawing.Image)(resources.GetObject("mayusculasBtn.Image")));
            this.mayusculasBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mayusculasBtn.Name = "mayusculasBtn";
            this.mayusculasBtn.Size = new System.Drawing.Size(37, 28);
            this.mayusculasBtn.Text = "Change Case";
            // 
            // lowercaseToolStripMenuItem
            // 
            this.lowercaseToolStripMenuItem.Name = "lowercaseToolStripMenuItem";
            this.lowercaseToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.lowercaseToolStripMenuItem.Text = "&lowercase";
            // 
            // uppercaseToolStripMenuItem
            // 
            this.uppercaseToolStripMenuItem.Name = "uppercaseToolStripMenuItem";
            this.uppercaseToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.uppercaseToolStripMenuItem.Text = "&UPPERCASE";
            // 
            // borrarBtn
            // 
            this.borrarBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.borrarBtn.Image = ((System.Drawing.Image)(resources.GetObject("borrarBtn.Image")));
            this.borrarBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.borrarBtn.Name = "borrarBtn";
            this.borrarBtn.Size = new System.Drawing.Size(28, 28);
            this.borrarBtn.Text = "Clear All Formatting";
            // 
            // negritaBtn
            // 
            this.negritaBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.negritaBtn.Image = ((System.Drawing.Image)(resources.GetObject("negritaBtn.Image")));
            this.negritaBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.negritaBtn.Name = "negritaBtn";
            this.negritaBtn.Size = new System.Drawing.Size(28, 28);
            this.negritaBtn.Text = "Bold";
            // 
            // italicabtn
            // 
            this.italicabtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italicabtn.Image = ((System.Drawing.Image)(resources.GetObject("italicabtn.Image")));
            this.italicabtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicabtn.Name = "italicabtn";
            this.italicabtn.Size = new System.Drawing.Size(28, 28);
            this.italicabtn.Text = "Italics";
            // 
            // subrayadoBtn
            // 
            this.subrayadoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subrayadoBtn.Image = ((System.Drawing.Image)(resources.GetObject("subrayadoBtn.Image")));
            this.subrayadoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subrayadoBtn.Name = "subrayadoBtn";
            this.subrayadoBtn.Size = new System.Drawing.Size(28, 28);
            this.subrayadoBtn.Text = "Underline";
            // 
            // alinearIzquierdaBtn
            // 
            this.alinearIzquierdaBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.alinearIzquierdaBtn.Image = ((System.Drawing.Image)(resources.GetObject("alinearIzquierdaBtn.Image")));
            this.alinearIzquierdaBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alinearIzquierdaBtn.Name = "alinearIzquierdaBtn";
            this.alinearIzquierdaBtn.Size = new System.Drawing.Size(28, 28);
            this.alinearIzquierdaBtn.Text = "Left Align";
            // 
            // centrarTextoBtn
            // 
            this.centrarTextoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.centrarTextoBtn.Image = ((System.Drawing.Image)(resources.GetObject("centrarTextoBtn.Image")));
            this.centrarTextoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.centrarTextoBtn.Name = "centrarTextoBtn";
            this.centrarTextoBtn.Size = new System.Drawing.Size(28, 28);
            this.centrarTextoBtn.Text = "Center Align";
            // 
            // alinearDerechaBtn
            // 
            this.alinearDerechaBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.alinearDerechaBtn.Image = ((System.Drawing.Image)(resources.GetObject("alinearDerechaBtn.Image")));
            this.alinearDerechaBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alinearDerechaBtn.Name = "alinearDerechaBtn";
            this.alinearDerechaBtn.Size = new System.Drawing.Size(28, 28);
            this.alinearDerechaBtn.Text = "Right Align";
            // 
            // EnlistarBtn
            // 
            this.EnlistarBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EnlistarBtn.Image = ((System.Drawing.Image)(resources.GetObject("EnlistarBtn.Image")));
            this.EnlistarBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EnlistarBtn.Name = "EnlistarBtn";
            this.EnlistarBtn.Size = new System.Drawing.Size(28, 28);
            this.EnlistarBtn.Text = "Bullet List";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkCyan;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historialMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 26);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // historialMenuItem
            // 
            this.historialMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verHistorialMenuItem});
            this.historialMenuItem.Name = "historialMenuItem";
            this.historialMenuItem.Size = new System.Drawing.Size(63, 22);
            this.historialMenuItem.Text = "Historial";
            // 
            // verHistorialMenuItem
            // 
            this.verHistorialMenuItem.Name = "verHistorialMenuItem";
            this.verHistorialMenuItem.Size = new System.Drawing.Size(135, 22);
            this.verHistorialMenuItem.Text = "Ver historial";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbLimite);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbContador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 26);
            this.panel1.TabIndex = 14;
            // 
            // lbLimite
            // 
            this.lbLimite.AutoSize = true;
            this.lbLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLimite.ForeColor = System.Drawing.Color.Gold;
            this.lbLimite.Location = new System.Drawing.Point(162, 6);
            this.lbLimite.Name = "lbLimite";
            this.lbLimite.Size = new System.Drawing.Size(19, 20);
            this.lbLimite.TabIndex = 3;
            this.lbLimite.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Limite de acciones: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(204, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad de Acciones:";
            // 
            // lbContador
            // 
            this.lbContador.AutoSize = true;
            this.lbContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContador.ForeColor = System.Drawing.Color.Gold;
            this.lbContador.Location = new System.Drawing.Point(378, 6);
            this.lbContador.Name = "lbContador";
            this.lbContador.Size = new System.Drawing.Size(19, 20);
            this.lbContador.TabIndex = 0;
            this.lbContador.Text = "0";
            // 
            // imagenA
            // 
            this.imagenA.BackColor = System.Drawing.SystemColors.Window;
            this.imagenA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imagenA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.imagenA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagenA.Location = new System.Drawing.Point(808, 50);
            this.imagenA.Name = "imagenA";
            this.imagenA.Size = new System.Drawing.Size(147, 31);
            this.imagenA.TabIndex = 18;
            this.imagenA.Text = "Adjunar Imagen";
            this.imagenA.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(955, 778);
            this.Controls.Add(this.imagenA);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cuadroTexto);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TextEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Note Editor ";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox cuadroTexto;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton guardarBtn;
        public System.Windows.Forms.ToolStripButton abrirBtn;
        public System.Windows.Forms.ToolStripComboBox tipoLetraBtn;
        public System.Windows.Forms.ToolStripComboBox tamanioLetraSlc;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton negritaBtn;
        public System.Windows.Forms.ToolStripButton italicabtn;
        public System.Windows.Forms.ToolStripButton subrayadoBtn;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripDropDownButton colorBnt;
        public System.Windows.Forms.ToolStripButton alinearIzquierdaBtn;
        public System.Windows.Forms.ToolStripButton centrarTextoBtn;
        public System.Windows.Forms.ToolStripButton alinearDerechaBtn;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripButton EnlistarBtn;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripButton atrasBtn;
        public System.Windows.Forms.ToolStripButton siguienteBtn;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem deleteStripMenuItem;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.PrintDialog printDialog;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        public System.Windows.Forms.ToolStripDropDownButton mayusculasBtn;
        public System.Windows.Forms.ToolStripMenuItem lowercaseToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem uppercaseToolStripMenuItem;
       // public System.Windows.Forms.FontDialog fontDialog1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.ToolStripButton borrarBtn;
        public System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        public System.Drawing.Printing.PrintDocument printDocument;
        public System.Windows.Forms.ToolStripButton imprimirBtn;
        public System.Windows.Forms.ToolStripButton vistaPreviaBtn;
     //   public System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbContador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbLimite;
        public System.Windows.Forms.ToolStripMenuItem historialMenuItem;
        public System.Windows.Forms.ToolStripMenuItem verHistorialMenuItem;
        public System.Windows.Forms.Button imagenA;
        public System.Windows.Forms.Timer timer1;
    }
}