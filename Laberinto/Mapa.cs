using System;
using System.Collections.Generic;
using System.Drawing;

namespace Laberinto
{
    [Flags]
    public enum Direccion
    {
        Ninguna = 0,
        Arriba = 1,
        Abajo = 2,
        Izquierda = 4,
        Derecha = 8,
        Todas = Arriba | Abajo | Izquierda | Derecha
    }

    /// <summary>
    /// Laberinto cuadrado de celdas. Cada celda guarda las paredes que aún la cierran.
    /// Se genera con backtracking aleatorio, así siempre existe un camino entre inicio y meta.
    /// </summary>
    public class Mapa
    {
        public static readonly Direccion[] Direcciones =
        {
            Direccion.Arriba,
            Direccion.Abajo,
            Direccion.Izquierda,
            Direccion.Derecha
        };

        private readonly Direccion[,] paredes;

        public Mapa(int tamano, Random rng)
        {
            Tamano = tamano;
            paredes = new Direccion[tamano, tamano];

            for (int x = 0; x < tamano; x++)
            {
                for (int y = 0; y < tamano; y++)
                {
                    paredes[x, y] = Direccion.Todas;
                }
            }

            GenerarLaberinto(rng);
        }

        public int Tamano { get; private set; }

        public Point Inicio
        {
            get { return new Point(0, 0); }
        }

        public Point Meta
        {
            get { return new Point(Tamano - 1, Tamano - 1); }
        }

        public Direccion ParedesDe(Point celda)
        {
            return paredes[celda.X, celda.Y];
        }

        public bool PuedeMover(Point celda, Direccion direccion)
        {
            Point destino = Desplazar(celda, direccion);
            return EnRango(destino) && (paredes[celda.X, celda.Y] & direccion) == Direccion.Ninguna;
        }

        public Point Desplazar(Point celda, Direccion direccion)
        {
            switch (direccion)
            {
                case Direccion.Arriba: return new Point(celda.X, celda.Y - 1);
                case Direccion.Abajo: return new Point(celda.X, celda.Y + 1);
                case Direccion.Izquierda: return new Point(celda.X - 1, celda.Y);
                case Direccion.Derecha: return new Point(celda.X + 1, celda.Y);
                default: throw new ArgumentOutOfRangeException("direccion");
            }
        }

        public bool EnRango(Point celda)
        {
            return celda.X >= 0 && celda.Y >= 0 && celda.X < Tamano && celda.Y < Tamano;
        }

        private static Direccion Opuesta(Direccion direccion)
        {
            switch (direccion)
            {
                case Direccion.Arriba: return Direccion.Abajo;
                case Direccion.Abajo: return Direccion.Arriba;
                case Direccion.Izquierda: return Direccion.Derecha;
                case Direccion.Derecha: return Direccion.Izquierda;
                default: throw new ArgumentOutOfRangeException("direccion");
            }
        }

        // Recorrido en profundidad iterativo: crea un laberinto perfecto (sin ciclos).
        private void GenerarLaberinto(Random rng)
        {
            bool[,] visitada = new bool[Tamano, Tamano];
            Stack<Point> pila = new Stack<Point>();

            visitada[Inicio.X, Inicio.Y] = true;
            pila.Push(Inicio);

            while (pila.Count > 0)
            {
                Point actual = pila.Peek();
                List<Direccion> libres = new List<Direccion>();

                foreach (Direccion direccion in Direcciones)
                {
                    Point vecino = Desplazar(actual, direccion);
                    if (EnRango(vecino) && !visitada[vecino.X, vecino.Y])
                    {
                        libres.Add(direccion);
                    }
                }

                if (libres.Count == 0)
                {
                    pila.Pop();
                    continue;
                }

                Direccion elegida = libres[rng.Next(libres.Count)];
                Point siguiente = Desplazar(actual, elegida);

                QuitarPared(actual, elegida);
                visitada[siguiente.X, siguiente.Y] = true;
                pila.Push(siguiente);
            }
        }

        private void QuitarPared(Point celda, Direccion direccion)
        {
            Point vecino = Desplazar(celda, direccion);
            paredes[celda.X, celda.Y] &= ~direccion;
            paredes[vecino.X, vecino.Y] &= ~Opuesta(direccion);
        }
    }
}
