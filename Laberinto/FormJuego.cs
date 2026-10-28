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
        private List<Point> rutaBotAStar = new List<Point>();
        private List<Point> rutaBotDFS = new List<Point>();

        private int indiceBotAStar = 0;
        private int indiceBotDFS = 0;

        private Point posBotAStar;
        private Point posBotDFS;

        private bool carreraEnCurso = false;
        public FormJuego(ModoJuego modo)
        {
            InitializeComponent();
            this.ModoActual = modo;
            this.Text = "" + modo.ToString();
        }

        private void FormJuego_Load(object sender, EventArgs e)
        {
            NuevoLaberinto();
            if (ModoActual == ModoJuego.BotVsBot)
            {
                lblEstado.Text = "Presiona 'INICIAR' para comenzar la carrera Bot A* vs Bot DFS";
                btnIniciar.Visible = true;
            }
            else
            {
                btnIniciar.Visible = false;
            }
        }
        public void NuevoLaberinto()
        {
            generador = new GeneradorLaberinto();
            laberintoMatriz = generador.GenerarLaberinto();

            if (pbLaberinto.Image != null) pbLaberinto.Image.Dispose();
            pbLaberinto.Image = generador.DibujarLaberinto(10);

            if (pbMinimapa.Image != null) pbMinimapa.Image.Dispose();
            pbMinimapa.Image = generador.DibujarLaberinto(3);

            // Colocar bots al inicio
            posBotAStar = generador.PosInicio;
            posBotDFS = generador.PosInicio;

            indiceBotAStar = 0;
            indiceBotDFS = 0;

            pbLaberinto.Invalidate();
            pbMinimapa.Invalidate();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (carreraEnCurso) return;

            lblEstado.Text = "Calculando rutas con A* y DFS...";
            rutaBotAStar = BuscadorRutas.ResolverAEstrella(laberintoMatriz, generador.PosInicio, generador.Salidas);
            rutaBotDFS = BuscadorRutas.ResolverDFS(laberintoMatriz, generador.PosInicio, generador.Salidas);

            // Validar que ambos algoritmos encontraron camino
            if (rutaBotAStar.Count == 0 || rutaBotDFS.Count == 0)
            {
                MessageBox.Show("No se encontró una ruta válida para la salida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Reiniciar índices y arrancar
            indiceBotAStar = 0;
            indiceBotDFS = 0;
            carreraEnCurso = true;
            btnIniciar.Enabled = false;

            lblEstado.Text = $"Bot A*: {rutaBotAStar.Count} pasos | Bot DFS: {rutaBotDFS.Count} pasos";
            tmrMovimiento.Start();
        }

        private void tmrMovimiento_Tick(object sender, EventArgs e)
        {
            bool botALlego = false;
            bool botBLlego = false;

            // Avanzar Bot A* (Cian)
            if (indiceBotAStar < rutaBotAStar.Count - 1)
            {
                indiceBotAStar++;
                posBotAStar = rutaBotAStar[indiceBotAStar];
            }
            else
            {
                botALlego = true;
            }

            // Avanzar Bot DFS (Dorado / Amarillo)
            if (indiceBotDFS < rutaBotDFS.Count - 1)
            {
                indiceBotDFS++;
                posBotDFS = rutaBotDFS[indiceBotDFS];
            }
            else
            {
                botBLlego = true;
            }

            // Forzar actualización visual inmediata de ambos mapas
            pbLaberinto.Invalidate();
            pbMinimapa.Invalidate();

            if (botALlego || botBLlego)
            {
                tmrMovimiento.Stop();
                carreraEnCurso = false;
                btnIniciar.Enabled = true;

                string ganador = (botALlego && !botBLlego) ? "¡Bot A* (Cian) ha ganado!" :
                                 (!botALlego && botBLlego) ? "¡Bot DFS (Dorado) ha ganado!" : "¡Empate simultáneo!";

                lblEstado.Text = $"{ganador} | Pasos A*: {rutaBotAStar.Count} vs Pasos DFS: {rutaBotDFS.Count}";

                MessageBox.Show($"{ganador}\n\n" +
                                $" Longitud ruta A*: {rutaBotAStar.Count} pasos (Óptima)\n" +
                                $" Longitud ruta DFS: {rutaBotDFS.Count} pasos (Exploración profunda)",
                                "Resultado de la Partida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pbLaberinto_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int escala = 10; 

            // Dibujar Bot A* (Cian)
            using (Brush bAStar = new SolidBrush(Color.FromArgb(56, 189, 248)))
            {
                g.FillEllipse(bAStar, posBotAStar.X * escala + 1, posBotAStar.Y * escala + 1, escala - 2, escala - 2);
            }

            // Dibujar Bot DFS (Amarillo / Dorado)
            using (Brush bDFS = new SolidBrush(Color.FromArgb(250, 204, 21)))
            {
                g.FillEllipse(bDFS, posBotDFS.X * escala + 1, posBotDFS.Y * escala + 1, escala - 2, escala - 2);
            }
        }

        private void pbMinimapa_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int escala = 3;

            // Indicador Bot A*
            using (Brush bAStar = new SolidBrush(Color.FromArgb(56, 189, 248)))
            {
                g.FillRectangle(bAStar, posBotAStar.X * escala, posBotAStar.Y * escala, escala + 1, escala + 1);
            }

            // Indicador Bot DFS
            using (Brush bDFS = new SolidBrush(Color.FromArgb(250, 204, 21)))
            {
                g.FillRectangle(bDFS, posBotDFS.X * escala, posBotDFS.Y * escala, escala + 1, escala + 1);
            }
        }
    }
}
