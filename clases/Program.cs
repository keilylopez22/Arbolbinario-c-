namespace tareaarbol.clases
{
    class Program
    {


        
    }
    class Nodo
    {
        public string valor;
        public Nodo izq;
        public Nodo der;
        //constructor 
        public Nodo(string valor)
        {
            this.valor = valor;
            izq = null;
            der = null;
        }
    }
    class ArbolBinario
    {
        public Nodo raiz;
        //constructor
        public ArbolBinario()
        {
            raiz = null;
        }
        //metodo preorden
        public void preorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.valor + " ");
                preorden(nodo.izq);
                preorden(nodo.der);
            }
        }
        //metodo inorden
        public void inorden(Nodo nodo)
        {
            if (nodo != null)
            {
                inorden(nodo.izq);
                Console.Write(nodo.valor + " ");
                inorden(nodo.der);
            }
        }
        //metodo postorden
        public void postorden(Nodo nodo)
        {
            if (nodo != null)
            {
                postorden(nodo.izq);
                postorden(nodo.der);
                Console.Write(nodo.valor + " ");
            }
        }
        //metodo insertar nodos al arbol
        public void InsertarNodo(string valor)
        {
            if (raiz == null)
            {
                raiz = new Nodo(valor);
                return;
            }

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();

                // Insertar en el primer espacio disponible
                if (actual.izq == null)
                {
                    actual.izq = new Nodo(valor);
                    return;
                }
                else
                {
                    cola.Enqueue(actual.izq);
                }

                if (actual.der == null)
                {
                    actual.der = new Nodo(valor);
                    return;
                }
                else
                {
                    cola.Enqueue(actual.der);
                }
            }
        }
        //propiedades del arbol
        public int CalcularAltura(Nodo nodo)
        {


            if (nodo == null)
                return 0;

            int alturaIzq = CalcularAltura(nodo.izq);
            int alturaDer = CalcularAltura(nodo.der);

            return Math.Max(alturaIzq, alturaDer) + 1;
            /*if (nodo == null)
            {
                return 0;
            }
            else
            {
                int alturaIzq = Altura(nodo.izq);
                int alturaDer = Altura(nodo.der);
                //return Math.Max(alturaIzq, alturaDer) + 1;
                if (alturaIzq > alturaDer)
                {
                    return alturaIzq + 1;
                }
                else
                {
                    return alturaDer + 1;
                }
            }*/
        }


        // Método para calcular el orden de un árbol
        public int CalcularOrden(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(nodo);
            int maxHijos = 0;

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();
                int hijos = 0;

                if (actual.izq != null)
                {
                    cola.Enqueue(actual.izq);
                    hijos++;
                }
                if (actual.der != null)
                {
                    cola.Enqueue(actual.der);
                    hijos++;
                }

                maxHijos = Math.Max(maxHijos, hijos);
            }

            return maxHijos;
        }


        //calcular el grado del arbol
        public int CalcularGrado(Nodo nodo)
        {

            if (raiz == null)
                return 0;

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(raiz);

            int totalNodos = 0;
            int niveles = 0;

            while (cola.Count > 0)
            {
                int nodosEnNivel = cola.Count;
                totalNodos += nodosEnNivel;
                niveles++;

                for (int i = 0; i < nodosEnNivel; i++)
                {
                    Nodo actual = cola.Dequeue();
                    if (actual.izq != null) cola.Enqueue(actual.izq);
                    if (actual.der != null) cola.Enqueue(actual.der);
                }
            }

            // metodo para calcular el orden de un nodo





            return (int)((double)totalNodos / niveles);

        }
        // Eliminar el modificador 'public' de los métodos dentro de la clase ArbolBinario
        public void ImprimirArbol()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            // Obtener la lista de niveles del árbol
            List<List<string>> niveles = ConstruirNiveles(raiz);

            foreach (var nivel in niveles)
            {
                foreach (var item in nivel)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }

        // Construye una lista de listas para representar el árbol en niveles con los caracteres / \
        private List<List<string>> ConstruirNiveles(Nodo raiz)
        {
            List<List<string>> resultado = new List<List<string>>();
            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                int nivelSize = cola.Count;
                List<string> nivelActual = new List<string>();
                List<string> conexiones = new List<string>();

                for (int i = 0; i < nivelSize; i++)
                {
                    Nodo nodo = cola.Dequeue();
                    nivelActual.Add(nodo.valor.ToString());

                    if (nodo.izq != null || nodo.der != null)
                    {
                        conexiones.Add("/");
                        conexiones.Add("\\");
                    }
                    else
                    {
                        conexiones.Add(" ");
                        conexiones.Add(" ");
                    }

                    if (nodo.izq != null) cola.Enqueue(nodo.izq);
                    if (nodo.der != null) cola.Enqueue(nodo.der);
                }

                resultado.Add(nivelActual);
                resultado.Add(conexiones);
            }
            return resultado;
        }


        //recorridos del arbol
        bool BuscarPreorden(Nodo nodo, string valor, ref int comparaciones)
            {
                if (nodo == null)
                    return false;

                comparaciones++;
                Console.Write(nodo.valor + " "); // Imprimir el camino recorrido

                if (nodo.valor == valor)
                    return true;

                return BuscarPreorden(nodo.izq, valor, ref comparaciones) ||
                       BuscarPreorden(nodo.der, valor, ref comparaciones);
            }

            bool BuscarInorden(Nodo nodo, string valor, ref int comparaciones)
            {
                if (nodo == null)
                    return false;

                if (BuscarInorden(nodo.izq, valor, ref comparaciones))
                    return true;

                comparaciones++;
                Console.Write(nodo.valor + " "); // Imprimir el camino recorrido

                if (nodo.valor == valor)
                    return true;

                return BuscarInorden(nodo.der, valor, ref comparaciones);
            }

            bool BuscarPostorden(Nodo nodo, string valor, ref int comparaciones)
            {
                if (nodo == null)
                    return false;

                if (BuscarPostorden(nodo.izq, valor, ref comparaciones))
                    return true;

                if (BuscarPostorden(nodo.der, valor, ref comparaciones))
                    return true;

                comparaciones++;
                Console.Write(nodo.valor + " "); // Imprimir el camino recorrido

                if (nodo.valor == valor)
                    return true;

                return false;
            }




    }

}
    


