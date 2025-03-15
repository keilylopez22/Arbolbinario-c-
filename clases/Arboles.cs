using System;
using System.Collections.Generic;

class Nodo
{
    public string valor;
    public Nodo izquierdo;
    public Nodo derecho;

    public Nodo(string valor)
    {
        this.valor = valor;
        this.izquierdo = null;
        this.derecho = null;
    }
}

class ArbolBinario
{
    public Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    public void Agregar(string valor)
    {
        raiz = AgregarRecursivo(raiz, valor);
    }

    private Nodo AgregarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        Console.Write($"¿Agregar {valor} a la izquierda o derecha de {nodo.valor}? (I/D): ");
        string direccion = Console.ReadLine().ToUpper();

        if (direccion == "I")
            nodo.izquierdo = AgregarRecursivo(nodo.izquierdo, valor);
        else
            nodo.derecho = AgregarRecursivo(nodo.derecho, valor);

        return nodo;
    }

    public void PreOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.valor + " ");
            PreOrden(nodo.izquierdo);
            PreOrden(nodo.derecho);
        }
    }

    public void InOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrden(nodo.izquierdo);
            Console.Write(nodo.valor + " ");
            InOrden(nodo.derecho);
        }
    }

    public void PostOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrden(nodo.izquierdo);
            PostOrden(nodo.derecho);
            Console.Write(nodo.valor + " ");
        }
    }

    public int Altura(Nodo nodo)
    {
        if (nodo == null)
            return 0;
        return 1 + Math.Max(Altura(nodo.izquierdo), Altura(nodo.derecho));
    }

    public int Grado(Nodo nodo)
    {
        if (nodo == null)
            return 0;
        int gradoActual = (nodo.izquierdo != null ? 1 : 0) + (nodo.derecho != null ? 1 : 0);
        return Math.Max(gradoActual, Math.Max(Grado(nodo.izquierdo), Grado(nodo.derecho)));
    }

    public void ImprimirArbol(Nodo nodo, int nivel = 0)
    {
        if (nodo == null)
            return;

        ImprimirArbol(nodo.derecho, nivel + 1);
        Console.WriteLine(new string(' ', nivel * 4) + nodo.valor);
        ImprimirArbol(nodo.izquierdo, nivel + 1);
    }

    public bool Buscar(Nodo nodo, string valor, List<string> camino)
    {
        if (nodo == null)
            return false;

        camino.Add(nodo.valor);

        if (nodo.valor == valor)
            return true;

        if (Buscar(nodo.izquierdo, valor, camino) || Buscar(nodo.derecho, valor, camino))
            return true;

        camino.RemoveAt(camino.Count - 1);
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();

        while (true)
        {
            Console.WriteLine("\nSeleccione una operación:");
            Console.WriteLine("1. Agregar nodo");
            Console.WriteLine("2. Recorrido PreOrden");
            Console.WriteLine("3. Recorrido InOrden");
            Console.WriteLine("4. Recorrido PostOrden");
            Console.WriteLine("5. Calcular altura del árbol");
            Console.WriteLine("6. Calcular grado del árbol");
            Console.WriteLine("7. Imprimir árbol");
            Console.WriteLine("8. Buscar un valor");
            Console.WriteLine("9. Salir");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el valor del nodo: ");
                    string valor = Console.ReadLine();
                    arbol.Agregar(valor);
                    break;
                case "2":
                    Console.WriteLine("Recorrido PreOrden:");
                    arbol.PreOrden(arbol.raiz);
                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine("Recorrido InOrden:");
                    arbol.InOrden(arbol.raiz);
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine("Recorrido PostOrden:");
                    arbol.PostOrden(arbol.raiz);
                    Console.WriteLine();
                    break;
                case "5":
                    Console.WriteLine("Altura del árbol: " + arbol.Altura(arbol.raiz));
                    break;
                case "6":
                    Console.WriteLine("Grado del árbol: " + arbol.Grado(arbol.raiz));
                    break;
                case "7":
                    Console.WriteLine("Estructura del árbol:");
                    arbol.ImprimirArbol(arbol.raiz);
                    break;
                case "8":
                    Console.Write("Ingrese el valor a buscar: ");
                    string buscar = Console.ReadLine();
                    List<string> camino = new List<string>();
                    if (arbol.Buscar(arbol.raiz, buscar, camino))
                    {
                        Console.WriteLine($"Valor encontrado. Camino: {string.Join(" -> ", camino)}");
                    }
                    else
                    {
                        Console.WriteLine("Valor no encontrado.");
                    }
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}