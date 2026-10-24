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
        public FormJuego(ModoJuego modo)
        {
            InitializeComponent();
            this.ModoActual = modo;
            this.Text = "" + modo.ToString();
        }

        private void FormJuego_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
