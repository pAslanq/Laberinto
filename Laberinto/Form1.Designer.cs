namespace Laberinto
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBotVsBot = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnJugadorVsJugador = new System.Windows.Forms.Button();
            this.btnBotVsJugador = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBotVsBot
            // 
            this.btnBotVsBot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnBotVsBot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBotVsBot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnBotVsBot.FlatAppearance.BorderSize = 2;
            this.btnBotVsBot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotVsBot.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotVsBot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnBotVsBot.Location = new System.Drawing.Point(146, 143);
            this.btnBotVsBot.Name = "btnBotVsBot";
            this.btnBotVsBot.Size = new System.Drawing.Size(252, 51);
            this.btnBotVsBot.TabIndex = 0;
            this.btnBotVsBot.Text = "Bot VS Bot";
            this.btnBotVsBot.UseVisualStyleBackColor = false;
            this.btnBotVsBot.Click += new System.EventHandler(this.button1_Click);
            this.btnBotVsBot.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btnBotVsBot.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnJugadorVsJugador);
            this.panel1.Controls.Add(this.btnBotVsJugador);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBotVsBot);
            this.panel1.Location = new System.Drawing.Point(180, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 495);
            this.panel1.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnSalir.Location = new System.Drawing.Point(146, 405);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(252, 51);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btnJugadorVsJugador
            // 
            this.btnJugadorVsJugador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnJugadorVsJugador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJugadorVsJugador.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnJugadorVsJugador.FlatAppearance.BorderSize = 2;
            this.btnJugadorVsJugador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJugadorVsJugador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugadorVsJugador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnJugadorVsJugador.Location = new System.Drawing.Point(146, 316);
            this.btnJugadorVsJugador.Name = "btnJugadorVsJugador";
            this.btnJugadorVsJugador.Size = new System.Drawing.Size(252, 51);
            this.btnJugadorVsJugador.TabIndex = 3;
            this.btnJugadorVsJugador.Text = "Jugador VS Jugador";
            this.btnJugadorVsJugador.UseVisualStyleBackColor = false;
            this.btnJugadorVsJugador.Click += new System.EventHandler(this.btnJugadorVsJugador_Click);
            this.btnJugadorVsJugador.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btnJugadorVsJugador.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btnBotVsJugador
            // 
            this.btnBotVsJugador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnBotVsJugador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBotVsJugador.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.btnBotVsJugador.FlatAppearance.BorderSize = 2;
            this.btnBotVsJugador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotVsJugador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotVsJugador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.btnBotVsJugador.Location = new System.Drawing.Point(146, 232);
            this.btnBotVsJugador.Name = "btnBotVsJugador";
            this.btnBotVsJugador.Size = new System.Drawing.Size(252, 51);
            this.btnBotVsJugador.TabIndex = 2;
            this.btnBotVsJugador.Text = "Bot VS Jugador";
            this.btnBotVsJugador.UseVisualStyleBackColor = false;
            this.btnBotVsJugador.Click += new System.EventHandler(this.btnBotVsJugador_Click);
            this.btnBotVsJugador.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btnBotVsJugador.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.label1.Location = new System.Drawing.Point(141, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "LABERINTO INTELIGENTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.label2.Location = new System.Drawing.Point(142, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "SELECCIONA EL MODO DE JUEGO";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(971, 614);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laberinto Inteligente - Menú";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBotVsBot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnJugadorVsJugador;
        private System.Windows.Forms.Button btnBotVsJugador;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label2;
    }
}

