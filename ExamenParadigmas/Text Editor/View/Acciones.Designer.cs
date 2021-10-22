
namespace NoteEditor
{
    partial class Acciones
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AccionesTbl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AccionesTbl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(40, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 320);
            this.panel1.TabIndex = 0;
            // 
            // AccionesTbl
            // 
            this.AccionesTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccionesTbl.Location = new System.Drawing.Point(0, 1);
            this.AccionesTbl.Name = "AccionesTbl";
            this.AccionesTbl.Size = new System.Drawing.Size(481, 314);
            this.AccionesTbl.TabIndex = 0;
            this.AccionesTbl.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccionesTbl_CellContentClick);
            // 
            // Acciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 315);
            this.Controls.Add(this.AccionesTbl);
            this.Controls.Add(this.panel1);
            this.Name = "Acciones";
            this.Text = "Historial de usuario";
            this.Load += new System.EventHandler(this.Acciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccionesTbl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView AccionesTbl;
    }
}