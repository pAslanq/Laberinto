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
    public partial class FormJuego : Form
    {
        public ModoJuego ModoActual { get; private set; }
        private GeneradorLaberinto generador;
        private int[,] laberintoMatriz;
        public FormJuego(ModoJuego modo)
        {
            InitializeComponent();
            this.ModoActual = modo;
            this.Text = "" + modo.ToString();
        }

        private void FormJuego_Load(object sender, EventArgs e)
        {
            NuevoLaberinto();
        }
        public void NuevoLaberinto()
        {
            generador = new GeneradorLaberinto();
            laberintoMatriz = generador.GenerarLaberinto();

            // Dibujar laberinto principal 10 píxeles por celda
            if (pbLaberinto.Image != null) pbLaberinto.Image.Dispose();
            pbLaberinto.Image = generador.DibujarLaberinto(10);

            // Dibujar minimapa 3 píxeles por celda
            if (pbMinimapa.Image != null) pbMinimapa.Image.Dispose();
            pbMinimapa.Image = generador.DibujarLaberinto(3);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
