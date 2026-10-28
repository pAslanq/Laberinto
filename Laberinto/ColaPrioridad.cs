using System.Collections.Generic;

namespace Laberinto
{
    /// <summary>
    /// Cola de prioridad (montículo binario mínimo). El elemento con menor prioridad sale primero.
    /// </summary>
    public class ColaPrioridad<T>
    {
        private readonly List<KeyValuePair<double, T>> elementos = new List<KeyValuePair<double, T>>();

        public int Count
        {
            get { return elementos.Count; }
        }

        public void Encolar(T elemento, double prioridad)
        {
            elementos.Add(new KeyValuePair<double, T>(prioridad, elemento));

            int i = elementos.Count - 1;
            while (i > 0)
            {
                int padre = (i - 1) / 2;
                if (elementos[padre].Key <= elementos[i].Key)
                {
                    break;
                }

                Intercambiar(i, padre);
                i = padre;
            }
        }

        public T Desencolar()
        {
            T primero = elementos[0].Value;
            int ultimo = elementos.Count - 1;

            elementos[0] = elementos[ultimo];
            elementos.RemoveAt(ultimo);

            int i = 0;
            while (true)
            {
                int izquierdo = 2 * i + 1;
                int derecho = izquierdo + 1;
                int menor = i;

                if (izquierdo < elementos.Count && elementos[izquierdo].Key < elementos[menor].Key)
                {
                    menor = izquierdo;
                }

                if (derecho < elementos.Count && elementos[derecho].Key < elementos[menor].Key)
                {
                    menor = derecho;
                }

                if (menor == i)
                {
                    break;
                }

                Intercambiar(i, menor);
                i = menor;
            }

            return primero;
        }

        private void Intercambiar(int a, int b)
        {
            KeyValuePair<double, T> temporal = elementos[a];
            elementos[a] = elementos[b];
            elementos[b] = temporal;
        }
    }
}
