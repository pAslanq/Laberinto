using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Laberinto
{
    /// <summary>
    /// Jugador controlado por teclado. Cada jugador tiene su propio conjunto de teclas.
    /// </summary>
    public class Jugador
    {
        private readonly Dictionary<Keys, Direccion> controles;

        public Jugador(string nombre, Color color, Dictionary<Keys, Direccion> controles, Point inicio)
        {
            Nombre = nombre;
            Color = color;
            this.controles = controles;

            Posicion = inicio;
            Recorrido = new List<Point> { inicio };
        }

        public string Nombre { get; private set; }

        public Color Color { get; private set; }

        public Point Posicion { get; private set; }

        public List<Point> Recorrido { get; private set; }

        public bool Mover(Keys tecla, Mapa mapa)
        {
            Direccion direccion;
            if (!controles.TryGetValue(tecla, out direccion) || !mapa.PuedeMover(Posicion, direccion))
            {
                return false;
            }

            Posicion = mapa.Desplazar(Posicion, direccion);
            Recorrido.Add(Posicion);
            return true;
        }

        public bool HaLlegado(Mapa mapa)
        {
            return Posicion == mapa.Meta;
        }
    }
}
