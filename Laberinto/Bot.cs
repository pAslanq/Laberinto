using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Laberinto
{
    /// <summary>
    /// Bot que calcula la ruta completa al inicio con un algoritmo de búsqueda
    /// y después la recorre paso a paso.
    /// </summary>
    public class Bot
    {
        private int indice;

        public Bot(string nombre, Color color, Busqueda algoritmo, Mapa mapa)
        {
            Nombre = nombre;
            Color = color;
            Algoritmo = algoritmo;

            Stopwatch cronometro = Stopwatch.StartNew();
            Ruta = algoritmo.Resolver(mapa, mapa.Inicio, mapa.Meta);
            cronometro.Stop();
            TiempoCalculoMs = cronometro.Elapsed.TotalMilliseconds;

            Posicion = mapa.Inicio;
            Recorrido = new List<Point> { mapa.Inicio };
        }

        public string Nombre { get; private set; }

        public Color Color { get; private set; }

        public Busqueda Algoritmo { get; private set; }

        public List<Point> Ruta { get; private set; }

        public double TiempoCalculoMs { get; private set; }

        public int NodosExplorados
        {
            get { return Algoritmo.NodosExplorados; }
        }

        public Point Posicion { get; private set; }

        public List<Point> Recorrido { get; private set; }

        public void Avanzar()
        {
            if (indice >= Ruta.Count - 1)
            {
                return;
            }

            indice++;
            Posicion = Ruta[indice];
            Recorrido.Add(Posicion);
        }

        public bool HaLlegado(Mapa mapa)
        {
            return Posicion == mapa.Meta;
        }
    }
}
