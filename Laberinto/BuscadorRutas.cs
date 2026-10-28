using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    internal class BuscadorRutas
    {
        private static readonly Point[] Direcciones = new Point[]
        {
            new Point(0, -1), // Arriba
            new Point(0, 1),  // Abajo
            new Point(-1, 0), // Izquierda
            new Point(1, 0)   // Derecha
        };

        // bot A*
        private class NodoAEstrella
        {
            public Point Posicion;
            public NodoAEstrella Padre;
            public int G; // Costo desde el inicio
            public int H; // Heurística estimada al destino
            public int F => G + H;

            public NodoAEstrella(Point pos, NodoAEstrella padre, int g, int h)
            {
                Posicion = pos;
                Padre = padre;
                G = g;
                H = h;
            }
        }

        public static List<Point> ResolverAEstrella(int[,] matriz, Point inicio, List<Point> salidas)
        {
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);

            List<NodoAEstrella> abiertos = new List<NodoAEstrella>();
            HashSet<Point> cerrados = new HashSet<Point>();

            int hInicial = CalcularDistanciaMinima(inicio, salidas);
            abiertos.Add(new NodoAEstrella(inicio, null, 0, hInicial));

            while (abiertos.Count > 0)
            {
                // Extraer el nodo con menor F
                abiertos.Sort((a, b) => a.F.CompareTo(b.F));
                NodoAEstrella actual = abiertos[0];
                abiertos.RemoveAt(0);

                // ¿Llegamos a alguna de las salidas?
                if (salidas.Contains(actual.Posicion))
                {
                    return ReconstruirRuta(actual);
                }

                cerrados.Add(actual.Posicion);

                foreach (var dir in Direcciones)
                {
                    Point vecino = new Point(actual.Posicion.X + dir.X, actual.Posicion.Y + dir.Y);

                    if (vecino.X < 0 || vecino.X >= columnas || vecino.Y < 0 || vecino.Y >= filas)
                        continue;

                    if (matriz[vecino.Y, vecino.X] == GeneradorLaberinto.PARED || cerrados.Contains(vecino))
                        continue;

                    int nuevoG = actual.G + 1;
                    NodoAEstrella nodoEnAbiertos = abiertos.Find(n => n.Posicion == vecino);

                    if (nodoEnAbiertos == null)
                    {
                        int h = CalcularDistanciaMinima(vecino, salidas);
                        abiertos.Add(new NodoAEstrella(vecino, actual, nuevoG, h));
                    }
                    else if (nuevoG < nodoEnEnAbiertos(nodoEnAbiertos, nuevoG))
                    {
                        nodoEnAbiertos.G = nuevoG;
                        nodoEnAbiertos.Padre = actual;
                    }
                }
            }

            return new List<Point>(); // Sin salida
        }

        private static int nodoEnEnAbiertos(NodoAEstrella n, int nuevoG) => n.G;

        private static int CalcularDistanciaMinima(Point p, List<Point> salidas)
        {
            int min = int.MaxValue;
            foreach (var salida in salidas)
            {
                int dist = Math.Abs(p.X - salida.X) + Math.Abs(p.Y - salida.Y); // Distancia Manhattan
                if (dist < min) min = dist;
            }
            return min;
        }

        // DFS 
        public static List<Point> ResolverDFS(int[,] matriz, Point inicio, List<Point> salidas)
        {
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);

            Stack<Point> pila = new Stack<Point>();
            HashSet<Point> visitados = new HashSet<Point>();
            Dictionary<Point, Point> mapaPadres = new Dictionary<Point, Point>();

            pila.Push(inicio);
            visitados.Add(inicio);

            Point salidaAlcanzada = Point.Empty;
            bool encontrado = false;

            while (pila.Count > 0 && !encontrado)
            {
                Point actual = pila.Pop();

                if (salidas.Contains(actual))
                {
                    salidaAlcanzada = actual;
                    encontrado = true;
                    break;
                }

                foreach (var dir in Direcciones)
                {
                    Point vecino = new Point(actual.X + dir.X, actual.Y + dir.Y);

                    if (vecino.X >= 0 && vecino.X < columnas && vecino.Y >= 0 && vecino.Y < filas)
                    {
                        if (matriz[vecino.Y, vecino.X] != GeneradorLaberinto.PARED && !visitados.Contains(vecino))
                        {
                            visitados.Add(vecino);
                            mapaPadres[vecino] = actual;
                            pila.Push(vecino);
                        }
                    }
                }
            }

            // Reconstruir la ruta DFS
            List<Point> ruta = new List<Point>();
            if (encontrado)
            {
                Point cur = salidaAlcanzada;
                while (cur != inicio)
                {
                    ruta.Add(cur);
                    cur = mapaPadres[cur];
                }
                ruta.Add(inicio);
                ruta.Reverse();
            }

            return ruta;
        }

        private static List<Point> ReconstruirRuta(NodoAEstrella nodo)
        {
            List<Point> camino = new List<Point>();
            while (nodo != null)
            {
                camino.Add(nodo.Posicion);
                nodo = nodo.Padre;
            }
            camino.Reverse();
            return camino;
        }
    }
}
