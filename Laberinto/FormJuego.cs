using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Laberinto
{
    public partial class FormJuego : Form
    {
        private static readonly Color Superficie = Color.FromArgb(30, 41, 59);
        private static readonly Color Pared = Color.FromArgb(71, 85, 105);
        private static readonly Color Texto = Color.FromArgb(148, 163, 184);
        private static readonly Color Cian = Color.FromArgb(56, 189, 248);
        private static readonly Color Amarillo = Color.FromArgb(250, 204, 21);
        private static readonly Color Verde = Color.FromArgb(34, 197, 94);
        private static readonly Color Rojo = Color.FromArgb(239, 68, 68);

        private const int InicioTablero = 120;
        private const int MargenTablero = 24;
        private const int VelocidadBotMs = 30;
        private const int VariacionBotMs = 10;
        private const double ZoomMinimo = 0.5;
        private const double ZoomMaximo = 5.0;
        private const double PasoZoom = 0.25;

        private readonly Form1 menu;
        private readonly Random rng = new Random();
        private readonly List<Timer> temporizadores = new List<Timer>();
        private List<Jugador> jugadores = new List<Jugador>();
        private List<Bot> bots = new List<Bot>();
        private Mapa mapa;
        private Point origen;
        private int celda;
        private double zoom = 2.5;
        private bool terminada;

        public FormJuego(ModoJuego modo, Dificultad dificultad, Form1 menu)
        {
            InitializeComponent();

            this.menu = menu;
            ModoActual = modo;
            DificultadActual = dificultad;
            Text = "Laberinto Inteligente - " + TextoModo(modo);

            IniciarPartida();
        }

        public ModoJuego ModoActual { get; private set; }

        public Dificultad DificultadActual { get; private set; }

        private int Tamano
        {
            get { return (int)DificultadActual; }
        }

        private void FormJuego_Load(object sender, EventArgs e)
        {
            AjustarControles();
        }

        private void FormJuego_Resize(object sender, EventArgs e)
        {
            AjustarControles();
            Invalidate();
        }

        // Las flechas las consume el formulario para navegar entre controles, así que
        // las teclas de juego se capturan aquí, antes de que lleguen a KeyDown.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys tecla = keyData & Keys.KeyCode;

            if (EsTeclaDeJuego(tecla))
            {
                MoverJugadores(tecla);
                return true;
            }

            if (tecla == Keys.Oemplus || tecla == Keys.Add)
            {
                CambiarZoom(PasoZoom);
                return true;
            }

            if (tecla == Keys.OemMinus || tecla == Keys.Subtract)
            {
                CambiarZoom(-PasoZoom);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FormJuego_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                RegresarAlMenu();
            }
        }

        private void FormJuego_FormClosed(object sender, FormClosedEventArgs e)
        {
            DetenerTemporizadores();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            RegresarAlMenu();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            IniciarPartida();
        }

        private void btnZoomMas_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            CambiarZoom(PasoZoom);
        }

        private void btnZoomMenos_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            CambiarZoom(-PasoZoom);
        }

        private void Boton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = btn.FlatAppearance.BorderColor;
                btn.ForeColor = Color.FromArgb(15, 23, 42);
            }
        }

        private void Boton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Superficie;
                btn.ForeColor = btn.FlatAppearance.BorderColor;
            }
        }

        private void IniciarPartida()
        {
            DetenerTemporizadores();
            terminada = false;

            mapa = new Mapa(Tamano, rng);
            jugadores = new List<Jugador>();
            bots = new List<Bot>();

            switch (ModoActual)
            {
                case ModoJuego.BotVsBot:
                    bots.Add(new Bot("Bot DFS", Rojo, new DFS(), mapa));
                    bots.Add(new Bot("Bot A*", Amarillo, new AStar(), mapa));
                    break;

                case ModoJuego.BotVsJugador:
                    jugadores.Add(new Jugador("Jugador", Cian, CrearControles(true, true), mapa.Inicio));
                    bots.Add(new Bot("Bot DFS", Rojo, new DFS(), mapa));
                    break;

                case ModoJuego.JugadorVsJugador:
                    jugadores.Add(new Jugador("Jugador 1", Cian, CrearControles(true, false), mapa.Inicio));
                    jugadores.Add(new Jugador("Jugador 2", Amarillo, CrearControles(false, true), mapa.Inicio));
                    break;
            }

            foreach (Bot bot in bots)
            {
                IniciarBot(bot);
            }

            lblGanador.Visible = false;
            btnReiniciar.Visible = false;

            AjustarControles();
            ActualizarTextos();
            Invalidate();
        }

        private void IniciarBot(Bot bot)
        {
            Timer temporizador = new Timer();
            temporizador.Interval = IntervaloBot();
            temporizador.Tick += (s, e) => MoverBot(bot, temporizador);
            temporizadores.Add(temporizador);
            temporizador.Start();
        }

        private void MoverBot(Bot bot, Timer temporizador)
        {
            if (terminada)
            {
                return;
            }

            bot.Avanzar();
            temporizador.Interval = IntervaloBot();
            Invalidate();

            if (bot.HaLlegado(mapa))
            {
                Terminar(bot.Nombre, bot.Color);
            }
        }

        private void MoverJugadores(Keys tecla)
        {
            if (terminada)
            {
                return;
            }

            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Mover(tecla, mapa))
                {
                    ActualizarTextos();
                    Invalidate();

                    if (jugador.HaLlegado(mapa))
                    {
                        Terminar(jugador.Nombre, jugador.Color);
                    }
                    return;
                }
            }
        }

        // Variación aleatoria en cada paso para que dos bots no vayan siempre sincronizados.
        private int IntervaloBot()
        {
            return VelocidadBotMs + rng.Next(-VariacionBotMs, VariacionBotMs + 1);
        }

        private void Terminar(string ganador, Color color)
        {
            terminada = true;
            DetenerTemporizadores();

            lblGanador.Text = "¡GANA " + ganador.ToUpper() + "!";
            lblGanador.ForeColor = color;
            lblGanador.Visible = true;
            btnReiniciar.Visible = true;

            AjustarControles();
            Invalidate();
        }

        private void CambiarZoom(double cambio)
        {
            zoom = Math.Max(ZoomMinimo, Math.Min(ZoomMaximo, Math.Round((zoom + cambio) / PasoZoom) * PasoZoom));
            ActualizarTextos();
            Invalidate();
        }

        private void RegresarAlMenu()
        {
            DetenerTemporizadores();
            menu.Show();
            Close();
        }

        private void DetenerTemporizadores()
        {
            foreach (Timer temporizador in temporizadores)
            {
                temporizador.Stop();
                temporizador.Dispose();
            }
            temporizadores.Clear();
        }

        // Área donde se dibuja el tablero, debajo de la barra superior.
        private Rectangle Vista()
        {
            return new Rectangle(MargenTablero, InicioTablero, ClientSize.Width - 2 * MargenTablero, ClientSize.Height - InicioTablero - MargenTablero);
        }

        private void AjustarControles()
        {
            if (mapa == null)
            {
                return;
            }

            btnRegresar.Location = new Point(ClientSize.Width - btnRegresar.Width - MargenTablero, 16);
            btnZoomMas.Location = new Point(btnRegresar.Left - btnZoomMas.Width - 8, 16);
            btnZoomMenos.Location = new Point(btnZoomMas.Left - btnZoomMenos.Width - 4, 16);

            Rectangle vista = Vista();
            int centroX = vista.Left + vista.Width / 2;
            int centroY = vista.Top + vista.Height / 2;
            lblGanador.Location = new Point(centroX - lblGanador.Width / 2, centroY - lblGanador.Height - 8);
            btnReiniciar.Location = new Point(centroX - btnReiniciar.Width / 2, centroY + 8);
        }

        // Calcula el tamaño de celda según el zoom y ubica el tablero.
        // Si el tablero cabe en la vista se centra; si no, la cámara sigue el centro de las piezas.
        private void CalcularVista()
        {
            Rectangle vista = Vista();
            int tamanoAjustado = Math.Max(2, Math.Min(vista.Width, vista.Height) / Tamano);
            celda = Math.Max(2, (int)Math.Round(tamanoAjustado * zoom));

            int lado = celda * Tamano;
            PointF centro = CentroPiezas();

            origen = new Point(
                CoordenadaCamara(vista.Left, vista.Width, lado, (centro.X + 0.5) * celda),
                CoordenadaCamara(vista.Top, vista.Height, lado, (centro.Y + 0.5) * celda));
        }

        private static int CoordenadaCamara(int inicio, int ancho, int lado, double focoPx)
        {
            if (lado <= ancho)
            {
                return inicio + (ancho - lado) / 2;
            }

            int deseado = (int)(inicio + ancho / 2.0 - focoPx);
            return Math.Max(inicio + ancho - lado, Math.Min(inicio, deseado));
        }

        private PointF CentroPiezas()
        {
            if (ModoActual == ModoJuego.BotVsJugador && jugadores.Count > 0)
            {
                return new PointF(jugadores[0].Posicion.X, jugadores[0].Posicion.Y);
            }

            if (ModoActual == ModoJuego.BotVsBot && bots.Count > 0)
            {
                Bot lider = bots.OrderByDescending(b => b.PasosRecorridos).First();
                return new PointF(lider.Posicion.X, lider.Posicion.Y);
            }

            List<Point> posiciones = jugadores.Select(j => j.Posicion).Concat(bots.Select(b => b.Posicion)).ToList();
            if (posiciones.Count == 0)
            {
                return new PointF(Tamano / 2f, Tamano / 2f);
            }

            return new PointF((float)posiciones.Average(p => p.X), (float)posiciones.Average(p => p.Y));
        }

        private void ActualizarTextos()
        {
            lblTitulo.Text = TextoModo(ModoActual) + "   ·   " + TextoDificultad(DificultadActual) + " " + Tamano + "x" + Tamano;

            List<string> partes = new List<string>();
            foreach (Bot bot in bots)
            {
                partes.Add(string.Format("{0}: {1} nodos explorados ({2:F1} ms)", bot.Nombre, bot.NodosExplorados, bot.TiempoCalculoMs));
            }
            foreach (Jugador jugador in jugadores)
            {
                partes.Add(string.Format("{0}: {1} pasos", jugador.Nombre, jugador.Recorrido.Count - 1));
            }
            lblInfo.Text = string.Join("   ·   ", partes);

            lblControles.Text = TextoControles(ModoActual) + "   ·   Zoom " + (int)Math.Round(zoom * 100) + "%";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (mapa == null)
            {
                return;
            }

            CalcularVista();

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SetClip(Vista());

            int lado = celda * Tamano;
            using (SolidBrush brochaTablero = new SolidBrush(Superficie))
            {
                g.FillRectangle(brochaTablero, origen.X, origen.Y, lado, lado);
            }

            using (SolidBrush brochaMeta = new SolidBrush(Verde))
            {
                g.FillRectangle(brochaMeta, Rectangle.Inflate(CeldaRect(mapa.Meta), -celda / 4, -celda / 4));
            }

            foreach (Jugador jugador in jugadores)
            {
                DibujarRecorrido(g, jugador.Recorrido, jugador.Color);
            }
            foreach (Bot bot in bots)
            {
                DibujarRecorrido(g, bot.Recorrido, bot.Color);
            }

            DibujarParedes(g);

            foreach (Jugador jugador in jugadores)
            {
                DibujarPieza(g, jugador.Posicion, jugador.Color);
            }
            foreach (Bot bot in bots)
            {
                DibujarPieza(g, bot.Posicion, bot.Color);
            }

            g.ResetClip();

            DibujarMinimapa(g);
        }

        private void DibujarMinimapa(Graphics g)
        {
            // Minimapa amplio tipo HUD superpuesto en la esquina superior derecha
            const int miniTamano = 220;
            const int margen = 20;

            int miniX = ClientSize.Width - miniTamano - margen;
            int miniY = btnRegresar.Bottom + 12;
            Rectangle miniRect = new Rectangle(miniX, miniY, miniTamano, miniTamano);

            using (SolidBrush brochaFondo = new SolidBrush(Color.FromArgb(230, 15, 23, 42)))
            using (Pen plumaBorde = new Pen(Color.FromArgb(56, 189, 248), 2))
            {
                g.FillRectangle(brochaFondo, miniRect);
                g.DrawRectangle(plumaBorde, miniRect);
            }

            float miniCelda = (float)miniTamano / Tamano;

            // Salida / Meta en verde
            float metaX = miniX + mapa.Meta.X * miniCelda;
            float metaY = miniY + mapa.Meta.Y * miniCelda;
            using (SolidBrush brochaMeta = new SolidBrush(Verde))
            {
                g.FillRectangle(brochaMeta, metaX, metaY, Math.Max(2f, miniCelda), Math.Max(2f, miniCelda));
            }

            // Inicio en gris/cian tenue
            float inicioX = miniX + mapa.Inicio.X * miniCelda;
            float inicioY = miniY + mapa.Inicio.Y * miniCelda;
            using (SolidBrush brochaInicio = new SolidBrush(Color.FromArgb(120, Cian)))
            {
                g.FillRectangle(brochaInicio, inicioX, inicioY, Math.Max(2f, miniCelda), Math.Max(2f, miniCelda));
            }

            // Dibujar paredes a escala miniatura si el tamaño lo permite
            using (Pen plumaParedMini = new Pen(Color.FromArgb(90, 71, 85, 105), 1))
            {
                for (int x = 0; x < Tamano; x++)
                {
                    for (int y = 0; y < Tamano; y++)
                    {
                        Point p = new Point(x, y);
                        Direccion dir = mapa.ParedesDe(p);
                        float px = miniX + x * miniCelda;
                        float py = miniY + y * miniCelda;

                        if ((dir & Direccion.Derecha) != Direccion.Ninguna)
                        {
                            g.DrawLine(plumaParedMini, px + miniCelda, py, px + miniCelda, py + miniCelda);
                        }
                        if ((dir & Direccion.Abajo) != Direccion.Ninguna)
                        {
                            g.DrawLine(plumaParedMini, px, py + miniCelda, px + miniCelda, py + miniCelda);
                        }
                    }
                }
            }

            // Recuadro del viewport / cámara actual
            Rectangle vista = Vista();
            float vpX = miniX + (float)(vista.Left - origen.X) / (celda * Tamano) * miniTamano;
            float vpY = miniY + (float)(vista.Top - origen.Y) / (celda * Tamano) * miniTamano;
            float vpW = (float)vista.Width / (celda * Tamano) * miniTamano;
            float vpH = (float)vista.Height / (celda * Tamano) * miniTamano;

            RectangleF rectCamara = new RectangleF(vpX, vpY, vpW, vpH);
            // Intersecar para que el viewport no se salga del borde del minimapa
            rectCamara.Intersect(miniRect);

            using (SolidBrush brochaVp = new SolidBrush(Color.FromArgb(40, 255, 255, 255)))
            using (Pen plumaVp = new Pen(Color.FromArgb(180, 255, 255, 255), 1))
            {
                g.FillRectangle(brochaVp, rectCamara);
                g.DrawRectangle(plumaVp, rectCamara.X, rectCamara.Y, rectCamara.Width, rectCamara.Height);
            }

            // Agentes / Bots en minimapa
            foreach (Bot bot in bots)
            {
                float bx = miniX + bot.Posicion.X * miniCelda;
                float by = miniY + bot.Posicion.Y * miniCelda;
                float tamPunto = Math.Max(4f, miniCelda * 1.5f);
                using (SolidBrush brocha = new SolidBrush(bot.Color))
                {
                    g.FillEllipse(brocha, bx - tamPunto / 2f + miniCelda / 2f, by - tamPunto / 2f + miniCelda / 2f, tamPunto, tamPunto);
                }
            }

            // Jugadores en minimapa
            foreach (Jugador jugador in jugadores)
            {
                float jx = miniX + jugador.Posicion.X * miniCelda;
                float jy = miniY + jugador.Posicion.Y * miniCelda;
                float tamPunto = Math.Max(4f, miniCelda * 1.5f);
                using (SolidBrush brocha = new SolidBrush(jugador.Color))
                {
                    g.FillEllipse(brocha, jx - tamPunto / 2f + miniCelda / 2f, jy - tamPunto / 2f + miniCelda / 2f, tamPunto, tamPunto);
                }
            }

            // Etiqueta sutil "MINIMAPA"
            using (Font fuenteMini = new Font("Segoe UI", 7.5f, FontStyle.Bold))
            using (SolidBrush brochaTexto = new SolidBrush(Color.FromArgb(148, 163, 184)))
            {
                g.DrawString("MINIMAPA", fuenteMini, brochaTexto, miniX + 4, miniY + 3);
            }
        }

        private void DibujarParedes(Graphics g)
        {
            float grosor = Math.Max(1, celda / 7);
            using (Pen pluma = new Pen(Pared, grosor))
            {
                for (int x = 0; x < Tamano; x++)
                {
                    for (int y = 0; y < Tamano; y++)
                    {
                        Point posicion = new Point(x, y);
                        Rectangle r = CeldaRect(posicion);
                        Direccion paredes = mapa.ParedesDe(posicion);

                        if ((paredes & Direccion.Arriba) != Direccion.Ninguna)
                        {
                            g.DrawLine(pluma, r.Left, r.Top, r.Right, r.Top);
                        }
                        if ((paredes & Direccion.Abajo) != Direccion.Ninguna)
                        {
                            g.DrawLine(pluma, r.Left, r.Bottom, r.Right, r.Bottom);
                        }
                        if ((paredes & Direccion.Izquierda) != Direccion.Ninguna)
                        {
                            g.DrawLine(pluma, r.Left, r.Top, r.Left, r.Bottom);
                        }
                        if ((paredes & Direccion.Derecha) != Direccion.Ninguna)
                        {
                            g.DrawLine(pluma, r.Right, r.Top, r.Right, r.Bottom);
                        }
                    }
                }
            }
        }

        private void DibujarRecorrido(Graphics g, List<Point> recorrido, Color color)
        {
            int margen = celda / 3;
            using (SolidBrush brocha = new SolidBrush(Color.FromArgb(70, color)))
            {
                foreach (Point posicion in recorrido)
                {
                    g.FillRectangle(brocha, Rectangle.Inflate(CeldaRect(posicion), -margen, -margen));
                }
            }
        }

        private void DibujarPieza(Graphics g, Point posicion, Color color)
        {
            int margen = Math.Max(1, celda / 5);
            using (SolidBrush brocha = new SolidBrush(color))
            {
                g.FillEllipse(brocha, Rectangle.Inflate(CeldaRect(posicion), -margen, -margen));
            }
        }

        private Rectangle CeldaRect(Point posicion)
        {
            return new Rectangle(origen.X + posicion.X * celda, origen.Y + posicion.Y * celda, celda, celda);
        }

        private static Dictionary<Keys, Direccion> CrearControles(bool wasd, bool flechas)
        {
            Dictionary<Keys, Direccion> controles = new Dictionary<Keys, Direccion>();

            if (wasd)
            {
                controles[Keys.W] = Direccion.Arriba;
                controles[Keys.S] = Direccion.Abajo;
                controles[Keys.A] = Direccion.Izquierda;
                controles[Keys.D] = Direccion.Derecha;
            }

            if (flechas)
            {
                controles[Keys.Up] = Direccion.Arriba;
                controles[Keys.Down] = Direccion.Abajo;
                controles[Keys.Left] = Direccion.Izquierda;
                controles[Keys.Right] = Direccion.Derecha;
            }

            return controles;
        }

        private static bool EsTeclaDeJuego(Keys tecla)
        {
            return tecla == Keys.Up || tecla == Keys.Down || tecla == Keys.Left || tecla == Keys.Right
                || tecla == Keys.W || tecla == Keys.A || tecla == Keys.S || tecla == Keys.D;
        }

        private static string TextoModo(ModoJuego modo)
        {
            switch (modo)
            {
                case ModoJuego.BotVsBot: return "Bot VS Bot";
                case ModoJuego.BotVsJugador: return "Bot VS Jugador";
                default: return "Jugador VS Jugador";
            }
        }

        private static string TextoDificultad(Dificultad dificultad)
        {
            switch (dificultad)
            {
                case Dificultad.Facil: return "Fácil";
                case Dificultad.Medio: return "Medio";
                default: return "Difícil";
            }
        }

        private static string TextoControles(ModoJuego modo)
        {
            switch (modo)
            {
                case ModoJuego.BotVsBot: return "Los bots calculan la ruta al inicio y compiten hasta la meta   ·   Esc: menú";
                case ModoJuego.BotVsJugador: return "Mover: flechas o WASD   ·   +/-: zoom   ·   Esc: menú";
                default: return "Jugador 1: WASD   ·   Jugador 2: flechas   ·   +/-: zoom   ·   Esc: menú";
            }
        }
    }
}
