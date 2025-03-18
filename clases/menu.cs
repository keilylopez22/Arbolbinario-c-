using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tareaarbol.clases
{
    class Menu

    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.menuPrincipal();


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
        //menu
        public void menuPrincipal()
        {
            ArbolBinario arbol = new ArbolBinario();
            int opcion = 0;
            string dato = "";
            do
            {
                Console.WriteLine("1.- Insertar");
                Console.WriteLine("2.- Ver recorrido Preorden");
                Console.WriteLine("3.-  Ver recorrido Inorden");
                Console.WriteLine("4.- Ver recorrido Postorden");
                Console.WriteLine("5.- Buscar un Valor");
                Console.WriteLine("6.- Mostrar grafica del arbol");
                Console.WriteLine("7.- Calcular propiedades del arbol");
                Console.WriteLine("8.- Salir");
                Console.WriteLine("Elija una opcion");
                opcion = Convert.ToInt32(Console.ReadLine());


                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el dato");
                        dato = Console.ReadLine();
                        arbol.InsertarNodo(dato);
                        break;
                    case 2:
                        arbol.preorden(arbol.raiz);
                        Console.WriteLine();
                        break;
                    case 3:
                        arbol.inorden(arbol.raiz);
                        Console.WriteLine();
                        break;
                    case 4:
                        arbol.postorden(arbol.raiz);
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.Write("Ingrese el valor del nuevo nodo: ");
                        string nuevoValor = Console.ReadLine();
                        arbol.InsertarNodo(nuevoValor);
                        Console.WriteLine($"Nodo '{nuevoValor}' agregado correctamente.");
                        break;
                    case 6:
                        arbol.ImprimirArbol();
                       
                        Console.WriteLine("Adios");
                        break;
                    case 7:
                        int subopcion;
                        do
                        {
                            Console.WriteLine("\n--- Propiedades del Árbol ---");
                            Console.WriteLine("1. Altura del Árbol");
                            Console.WriteLine("2. Grado del Árbol");
                            Console.WriteLine("3. Orden del Árbol");
                            Console.WriteLine("4. Regresar al menú principal");
                            Console.Write("Seleccione una opción: ");
                            subopcion = Convert.ToInt32(Console.ReadLine());

                            switch (subopcion)
                            {
                                case 1:
                                    Console.WriteLine($"Altura del árbol: {arbol.CalcularAltura(arbol.raiz)}");
                                    break;
                                case 2:
                                    Console.WriteLine($"Grado del árbol: {arbol.CalcularGrado(arbol.raiz)}");
                                    break;
                                case 3:
                                    Console.WriteLine($"Orden del árbol: {arbol.CalcularOrden(arbol.raiz):F2}");
                                    break;
                                case 4:
                                    Console.WriteLine("Regresando al menú principal...");
                                    //regresar al menú principal
                                    break;

                                     
                                    
                                default:
                                    Console.WriteLine("Opción no válida, intente de nuevo.");
                                    break;
                            }




                        } while (subopcion != 4);
                        break;
                    case 8:
                        Console.WriteLine("Adios");
                        
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            } while (opcion != 8);
        }




    }
}
