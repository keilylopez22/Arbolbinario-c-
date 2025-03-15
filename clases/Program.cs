namespace tareaarbol.clases
{
    class Program
    {
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

                    return (int)((double)totalNodos / niveles);
                // Eliminar el modificador 'public' de los métodos dentro de la clase ArbolBinario
                void ImprimirArbol()
                {
                    if (raiz == null)
                    {
                        Console.WriteLine("El árbol está vacío.");
                        return;
                    }

                    Queue<Nodo> cola = new Queue<Nodo>();
                    cola.Enqueue(raiz);

                    int nivel = 0;
                    while (cola.Count > 0)
                    {
                        int numNodosNivel = cola.Count; // Cantidad de nodos en el nivel actual
                        Console.Write($"Nivel {nivel}: ");

                        for (int i = 0; i < numNodosNivel; i++)
                        {
                            Nodo nodoActual = cola.Dequeue();
                            Console.Write(nodoActual.valor + " ");

                            // Agregar los hijos a la cola para el próximo nivel
                            if (nodoActual.izq != null) cola.Enqueue(nodoActual.izq);
                            if (nodoActual.der != null) cola.Enqueue(nodoActual.der);
                        }
                        Console.WriteLine(); // Salto de línea entre niveles
                        nivel++;
                    }
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
        static void Main(string[] args)
        {
            //instanciar el objeto Arbol de la clase ArbolBinario
            ArbolBinario arbol = new ArbolBinario();
            //crear arbol binario
            arbol.raiz = new Nodo("A");
            arbol.raiz.izq = new Nodo("B");
            arbol.raiz.der = new Nodo("C");
            arbol.raiz.izq.izq = new Nodo("D");
            arbol.raiz.izq.der = new Nodo("E");
            arbol.raiz.der.izq = new Nodo("F");
            arbol.raiz.der.der = new Nodo("G");

        }
    
    }
}
