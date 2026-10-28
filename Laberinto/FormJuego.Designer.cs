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
            this.components = new System.ComponentModel.Container();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pbMinimapa = new System.Windows.Forms.PictureBox();
            this.pbLaberinto = new System.Windows.Forms.PictureBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.tmrMovimiento = new System.Windows.Forms.Timer(this.components);
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
            this.btnSalir.Location = new System.Drawing.Point(671, 675);
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
            this.pbMinimapa.Location = new System.Drawing.Point(671, 116);
            this.pbMinimapa.Name = "pbMinimapa";
            this.pbMinimapa.Size = new System.Drawing.Size(183, 183);
            this.pbMinimapa.TabIndex = 6;
            this.pbMinimapa.TabStop = false;
            this.pbMinimapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMinimapa_Paint);
            // 
            // pbLaberinto
            // 
            this.pbLaberinto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbLaberinto.Location = new System.Drawing.Point(38, 116);
            this.pbLaberinto.Name = "pbLaberinto";
            this.pbLaberinto.Size = new System.Drawing.Size(610, 610);
            this.pbLaberinto.TabIndex = 7;
            this.pbLaberinto.TabStop = false;
            this.pbLaberinto.Paint += new System.Windows.Forms.PaintEventHandler(this.pbLaberinto_Paint);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnIniciar.FlatAppearance.BorderSize = 2;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnIniciar.Location = new System.Drawing.Point(671, 358);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(183, 51);
            this.btnIniciar.TabIndex = 8;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblEstado.Location = new System.Drawing.Point(79, 25);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(265, 30);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "LABERINTO INTELIGENTE";
            // 
            // tmrMovimiento
            // 
            this.tmrMovimiento.Interval = 50;
            this.tmrMovimiento.Tick += new System.EventHandler(this.tmrMovimiento_Tick);
            // 
            // FormJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1143, 765);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnIniciar);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pbMinimapa;
        private System.Windows.Forms.PictureBox pbLaberinto;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Timer tmrMovimiento;
    }
}