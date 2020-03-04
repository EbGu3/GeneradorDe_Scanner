using System;
using GeneradorDeScanner.Models;

namespace GeneradorDeScanner
{
    class MainClass
    {
        public static void Main(string[] args)
        {


            Console.WriteLine("----------------Lectura Expresion Regular-----------------" + "\n");
            Console.WriteLine("Ingrese la Direccion del archivo de texto");
            var DArchivo = Console.ReadLine().ToString();
            Archivo archivito = new Archivo(DArchivo);
            archivito.Lectura();
            

            Console.WriteLine("La expresion es:");
            archivito.Diccinarios();
            archivito.LecturaER();
            Console.ReadKey();

            

            

            





            Console.ReadLine();

        }
    }
}
