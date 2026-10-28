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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblControles = new System.Windows.Forms.Label();
            this.lblGanador = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnZoomMas = new System.Windows.Forms.Button();
            this.btnZoomMenos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTitulo.Location = new System.Drawing.Point(24, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 30);
            this.lblTitulo.TabIndex = 0;
            //
            // lblInfo
            //
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblInfo.Location = new System.Drawing.Point(26, 56);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 19);
            this.lblInfo.TabIndex = 1;
            //
            // lblControles
            //
            this.lblControles.AutoSize = true;
            this.lblControles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblControles.Location = new System.Drawing.Point(26, 84);
            this.lblControles.Name = "lblControles";
            this.lblControles.Size = new System.Drawing.Size(0, 15);
            this.lblControles.TabIndex = 2;
            //
            // lblGanador
            //
            this.lblGanador.AutoSize = true;
            this.lblGanador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGanador.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblGanador.Location = new System.Drawing.Point(0, 0);
            this.lblGanador.Name = "lblGanador";
            this.lblGanador.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.lblGanador.Size = new System.Drawing.Size(0, 0);
            this.lblGanador.TabIndex = 3;
            this.lblGanador.Visible = false;
            //
            // btnRegresar
            //
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnRegresar.FlatAppearance.BorderSize = 2;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnRegresar.Location = new System.Drawing.Point(800, 16);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(150, 40);
            this.btnRegresar.TabIndex = 4;
            this.btnRegresar.TabStop = false;
            this.btnRegresar.Text = "Menú";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            this.btnRegresar.MouseEnter += new System.EventHandler(this.Boton_MouseEnter);
            this.btnRegresar.MouseLeave += new System.EventHandler(this.Boton_MouseLeave);
            //
            // btnReiniciar
            //
            this.btnReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnReiniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReiniciar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnReiniciar.FlatAppearance.BorderSize = 2;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnReiniciar.Location = new System.Drawing.Point(0, 0);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(220, 44);
            this.btnReiniciar.TabIndex = 5;
            this.btnReiniciar.TabStop = false;
            this.btnReiniciar.Text = "Jugar de nuevo";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Visible = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            this.btnReiniciar.MouseEnter += new System.EventHandler(this.Boton_MouseEnter);
            this.btnReiniciar.MouseLeave += new System.EventHandler(this.Boton_MouseLeave);
            //
            // btnZoomMas
            //
            this.btnZoomMas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnZoomMas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomMas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnZoomMas.FlatAppearance.BorderSize = 2;
            this.btnZoomMas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomMas.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomMas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnZoomMas.Location = new System.Drawing.Point(600, 16);
            this.btnZoomMas.Name = "btnZoomMas";
            this.btnZoomMas.Size = new System.Drawing.Size(44, 40);
            this.btnZoomMas.TabIndex = 6;
            this.btnZoomMas.TabStop = false;
            this.btnZoomMas.Text = "+";
            this.btnZoomMas.UseVisualStyleBackColor = false;
            this.btnZoomMas.Click += new System.EventHandler(this.btnZoomMas_Click);
            this.btnZoomMas.MouseEnter += new System.EventHandler(this.Boton_MouseEnter);
            this.btnZoomMas.MouseLeave += new System.EventHandler(this.Boton_MouseLeave);
            //
            // btnZoomMenos
            //
            this.btnZoomMenos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnZoomMenos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomMenos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnZoomMenos.FlatAppearance.BorderSize = 2;
            this.btnZoomMenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomMenos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomMenos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnZoomMenos.Location = new System.Drawing.Point(540, 16);
            this.btnZoomMenos.Name = "btnZoomMenos";
            this.btnZoomMenos.Size = new System.Drawing.Size(44, 40);
            this.btnZoomMenos.TabIndex = 7;
            this.btnZoomMenos.TabStop = false;
            this.btnZoomMenos.Text = "-";
            this.btnZoomMenos.UseVisualStyleBackColor = false;
            this.btnZoomMenos.Click += new System.EventHandler(this.btnZoomMenos_Click);
            this.btnZoomMenos.MouseEnter += new System.EventHandler(this.Boton_MouseEnter);
            this.btnZoomMenos.MouseLeave += new System.EventHandler(this.Boton_MouseLeave);
            //
            // FormJuego
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnZoomMas);
            this.Controls.Add(this.btnZoomMenos);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.lblGanador);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblControles);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormJuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormJuego";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormJuego_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormJuego_KeyDown);
            this.Load += new System.EventHandler(this.FormJuego_Load);
            this.Resize += new System.EventHandler(this.FormJuego_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblControles;
        private System.Windows.Forms.Label lblGanador;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnZoomMas;
        private System.Windows.Forms.Button btnZoomMenos;
    }
}
