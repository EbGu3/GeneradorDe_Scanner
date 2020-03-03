using System;
using GeneradorDeScanner.Models;

namespace GeneradorDeScanner
{
    class MainClass
    {
        public static void Main(string[] args)
        {

           

            Console.WriteLine("Ingrese la Direccion del archivo de texto");
            var DArchivo = Console.ReadLine().ToString();

            Archivo archivito = new Archivo(DArchivo);
            

            Console.WriteLine("La expresion es:");
            archivito.Diccinarios();
            archivito.LecturaER();
            Console.ReadKey();

            

            archivito.Lectura();

            ArbolBinario arb = new ArbolBinario();

          /*  Nodo nodito = new Nodo("5");
            Nodo nodito1 = new Nodo("6");
            Nodo nodito2 = new Nodo("15");
            Nodo nodigo3 = new Nodo("4");
            
            arb.Insertar(nodito, 0);
            arb.Insertar(nodito1, 1);
            arb.Insertar(nodito2, 1);
            arb.Insertar(nodigo3, 2);
            arb.Insertar(nodito, 2);
            */
          





            Console.ReadLine();

        }
    }
}
