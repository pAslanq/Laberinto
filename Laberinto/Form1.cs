using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laberinto
{
    public enum ModoJuego
    {
        BotVsBot,
        BotVsJugador,
        JugadorVsJugador
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (panel1 != null)
            {
                panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
                panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (panel1 != null)
            {
                panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
                panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modo(ModoJuego.BotVsBot);
        }

        private void Modo(ModoJuego modo)
        {
            FormJuego form2 = new FormJuego(modo);
            form2.Show();
            this.Hide();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Color colorAcento = btn.FlatAppearance.BorderColor;
                btn.BackColor = colorAcento;
                btn.ForeColor = Color.FromArgb(15, 23, 42);
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Color colorAcento = btn.FlatAppearance.BorderColor;
                btn.BackColor = Color.FromArgb(30, 41, 59);
                btn.ForeColor = colorAcento;
            }   
        }

        private void btnBotVsJugador_Click(object sender, EventArgs e)
        {
            Modo(ModoJuego.BotVsJugador);
        }

        private void btnJugadorVsJugador_Click(object sender, EventArgs e)
        {
            Modo(ModoJuego.JugadorVsJugador);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
