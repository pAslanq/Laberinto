using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    internal class GeneradorLaberinto
    {
        public const int FILAS = 61;
        public const int COLUMNAS = 61;

        public const int PARED = 1;
        public const int CAMINO = 0;
        public const int INICIO = 2;
        public const int SALIDA = 3;

        private int[,] matriz;
        private Random rnd = new Random();

        public Point PosInicio { get; private set; }
        public List<Point> Salidas { get; private set; } = new List<Point>();

        public int[,] GenerarLaberinto()
        {
            matriz = new int[FILAS, COLUMNAS];
            Salidas.Clear();

            // Llenar la matriz de muros
            for (int r = 0; r < FILAS; r++)
            {
                for (int c = 0; c < COLUMNAS; c++)
                {
                    matriz[r, c] = PARED;
                }
            }

            // DFS con Backtracking usando una Pila
            Stack<Point> pila = new Stack<Point>();
            Point celdaInicial = new Point(1, 1);
            matriz[celdaInicial.Y, celdaInicial.X] = CAMINO;
            pila.Push(celdaInicial);

            int[][] direcciones = new int[][]
            {
                new int[] { 0, -2 }, // Arriba
                new int[] { 0, 2 },  // Abajo
                new int[] { -2, 0 }, // Izquierda
                new int[] { 2, 0 }   // Derecha
            };

            while (pila.Count > 0)
            {
                Point actual = pila.Peek();
                List<Point> vecinos = new List<Point>();

                foreach (var dir in direcciones)
                {
                    int nr = actual.Y + dir[1];
                    int nc = actual.X + dir[0];

                    if (nr > 0 && nr < FILAS - 1 && nc > 0 && nc < COLUMNAS - 1)
                    {
                        if (matriz[nr, nc] == PARED)
                        {
                            vecinos.Add(new Point(nc, nr));
                        }
                    }
                }

                if (vecinos.Count > 0)
                {
                    // Elegir vecino al azar
                    Point elegido = vecinos[rnd.Next(vecinos.Count)];

                    // Quitar muro intermedio
                    int muroY = actual.Y + (elegido.Y - actual.Y) / 2;
                    int muroX = actual.X + (elegido.X - actual.X) / 2;
                    matriz[muroY, muroX] = CAMINO;

                    // Marcar vecino como camino y apilar
                    matriz[elegido.Y, elegido.X] = CAMINO;
                    pila.Push(elegido);
                }
                else
                {
                    pila.Pop(); // Retroceso
                }
            }

            // Inicio
            PosInicio = new Point(1, 1);
            matriz[PosInicio.Y, PosInicio.X] = INICIO;

            // Salida 1
            Point salida1 = new Point(COLUMNAS - 2, FILAS - 1);
            matriz[FILAS - 2, COLUMNAS - 2] = CAMINO;
            matriz[salida1.Y, salida1.X] = SALIDA;
            Salidas.Add(salida1);

            // Salida 2
            Point salida2 = new Point(COLUMNAS - 2, 0);
            matriz[1, COLUMNAS - 2] = CAMINO;
            matriz[salida2.Y, salida2.X] = SALIDA;
            Salidas.Add(salida2);

            return matriz;
        }

        // Renderizado en un Bitmap
        public Bitmap DibujarLaberinto(int tamanoCelda)
        {
            Bitmap bmp = new Bitmap(COLUMNAS * tamanoCelda, FILAS * tamanoCelda);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Brush Pared = new SolidBrush(Color.FromArgb(30, 30, 30)))
                using (Brush Camino = new SolidBrush(Color.White))
                using (Brush Inicio = new SolidBrush(Color.LimeGreen))
                using (Brush Salida = new SolidBrush(Color.Red))
                {
                    for (int r = 0; r < FILAS; r++)
                    {
                        for (int c = 0; c < COLUMNAS; c++)
                        {
                            Brush b;
                            switch (matriz[r, c])
                            {
                                case PARED: b = Pared; break;
                                case INICIO: b = Inicio; break;
                                case SALIDA: b = Salida; break;
                                default: b = Camino; break;
                            }

                            g.FillRectangle(b, c * tamanoCelda, r * tamanoCelda, tamanoCelda, tamanoCelda);
                        }
                    }
                }
            }
            return bmp;
        }
    }
}
