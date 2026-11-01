using System;
using System.Collections.Generic;
using System.Drawing;

namespace Laberinto
{
    /// <summary>
    /// Búsqueda de ruta sobre el laberinto. Dijkstra y A* comparten el mismo código;
    /// lo único que cambia es la heurística (A* usa distancia Manhattan, Dijkstra usa 0).
    /// </summary>
    public abstract class Busqueda
    {
        public abstract string Nombre { get; }

        public int NodosExplorados { get; protected set; }

        protected abstract int Heuristica(Point celda, Point meta);

        // Devuelve la ruta de inicio a meta (ambos incluidos), o una lista vacía si no existe.
        public virtual List<Point> Resolver(Mapa mapa, Point inicio, Point meta)
        {
            int n = mapa.Tamano;
            int[,] costo = new int[n, n];
            Point[,] anterior = new Point[n, n];
            bool[,] cerrada = new bool[n, n];

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    costo[x, y] = int.MaxValue;
                }
            }

            NodosExplorados = 0;
            ColaPrioridad<Point> abiertas = new ColaPrioridad<Point>();

            costo[inicio.X, inicio.Y] = 0;
            abiertas.Encolar(inicio, Heuristica(inicio, meta));

            while (abiertas.Count > 0)
            {
                Point actual = abiertas.Desencolar();
                if (cerrada[actual.X, actual.Y])
                {
                    continue;
                }

                cerrada[actual.X, actual.Y] = true;
                NodosExplorados++;

                if (actual == meta)
                {
                    return Reconstruir(anterior, inicio, meta);
                }

                foreach (Direccion direccion in Mapa.Direcciones)
                {
                    if (!mapa.PuedeMover(actual, direccion))
                    {
                        continue;
                    }

                    Point vecino = mapa.Desplazar(actual, direccion);
                    if (cerrada[vecino.X, vecino.Y])
                    {
                        continue;
                    }

                    int nuevoCosto = costo[actual.X, actual.Y] + 1;
                    if (nuevoCosto < costo[vecino.X, vecino.Y])
                    {
                        costo[vecino.X, vecino.Y] = nuevoCosto;
                        anterior[vecino.X, vecino.Y] = actual;
                        abiertas.Encolar(vecino, nuevoCosto + Heuristica(vecino, meta));
                    }
                }
            }

            return new List<Point>();
        }

        protected static List<Point> Reconstruir(Point[,] anterior, Point inicio, Point meta)
        {
            List<Point> ruta = new List<Point> { meta };
            Point actual = meta;

            while (actual != inicio)
            {
                actual = anterior[actual.X, actual.Y];
                ruta.Add(actual);
            }

            ruta.Reverse();
            return ruta;
        }
    }

    public class DFS : Busqueda
    {
        public override string Nombre
        {
            get { return "DFS"; }
        }

        protected override int Heuristica(Point celda, Point meta)
        {
            return 0;
        }

        public override List<Point> Resolver(Mapa mapa, Point inicio, Point meta)
        {
            int n = mapa.Tamano;
            Point[,] anterior = new Point[n, n];
            bool[,] visitada = new bool[n, n];

            NodosExplorados = 0;
            Stack<Point> pila = new Stack<Point>();

            pila.Push(inicio);
            visitada[inicio.X, inicio.Y] = true;

            while (pila.Count > 0)
            {
                Point actual = pila.Pop();
                NodosExplorados++;

                if (actual == meta)
                {
                    return Reconstruir(anterior, inicio, meta);
                }

                foreach (Direccion direccion in Mapa.Direcciones)
                {
                    if (!mapa.PuedeMover(actual, direccion))
                    {
                        continue;
                    }

                    Point vecino = mapa.Desplazar(actual, direccion);
                    if (!visitada[vecino.X, vecino.Y])
                    {
                        visitada[vecino.X, vecino.Y] = true;
                        anterior[vecino.X, vecino.Y] = actual;
                        pila.Push(vecino);
                    }
                }
            }

            return new List<Point>();
        }
    }

    public class AStar : Busqueda
    {
        public override string Nombre
        {
            get { return "A*"; }
        }

        protected override int Heuristica(Point celda, Point meta)
        {
            return Math.Abs(meta.X - celda.X) + Math.Abs(meta.Y - celda.Y);
        }
    }

    public class Dijkstra : Busqueda
    {
        public override string Nombre
        {
            get { return "Dijkstra"; }
        }

        protected override int Heuristica(Point celda, Point meta)
        {
            return 0;
        }
    }
}
