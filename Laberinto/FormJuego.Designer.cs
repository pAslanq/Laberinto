namespace Laberinto
{
    partial class FormJuego
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.pbMinimapa = new System.Windows.Forms.PictureBox();
            this.pbLaberinto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLaberinto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnSalir.Location = new System.Drawing.Point(674, 250);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(183, 51);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Regresar";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pbMinimapa
            // 
            this.pbMinimapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMinimapa.Location = new System.Drawing.Point(674, 20);
            this.pbMinimapa.Name = "pbMinimapa";
            this.pbMinimapa.Size = new System.Drawing.Size(183, 183);
            this.pbMinimapa.TabIndex = 6;
            this.pbMinimapa.TabStop = false;
            // 
            // pbLaberinto
            // 
            this.pbLaberinto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbLaberinto.Location = new System.Drawing.Point(41, 20);
            this.pbLaberinto.Name = "pbLaberinto";
            this.pbLaberinto.Size = new System.Drawing.Size(610, 610);
            this.pbLaberinto.TabIndex = 7;
            this.pbLaberinto.TabStop = false;
            // 
            // FormJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1143, 765);
            this.Controls.Add(this.pbLaberinto);
            this.Controls.Add(this.pbMinimapa);
            this.Controls.Add(this.btnSalir);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormJuego";
            this.Text = "FormJuego";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormJuego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLaberinto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pbMinimapa;
        private System.Windows.Forms.PictureBox pbLaberinto;
    }
}